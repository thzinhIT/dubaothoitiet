using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace howto_weather_forecast2
{
    public partial class Form2 : Form
    {
        private TcpListener listener;
        private Task listeningTask;

        public Form2()
        {
            InitializeComponent();
            StartListening(); // Bắt đầu lắng nghe khi Form khởi động
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string receiverIP = txtReceiverID.Text; // Nhập địa chỉ IP của Client 2
            string weatherInfo = txtWeatherInfo.Text; // Thông tin thời tiết cần gửi

            SendWeatherInfo(receiverIP, weatherInfo);
        }

        private void SendWeatherInfo(string receiverIP, string weatherInfo)
        {
            try
            {
                using (TcpClient client = new TcpClient(receiverIP, 12345)) // Cổng 12345 là ví dụ
                {
                    // Chuyển thông tin thời tiết sang byte để gửi qua mạng
                    byte[] data = Encoding.UTF8.GetBytes(weatherInfo);

                    // Gửi dữ liệu
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);

                    txtLog.AppendText("Thông tin thời tiết đã được gửi đến " + receiverIP + ".\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi dữ liệu: " + ex.Message);
            }
        }

        private void StartListening()
        {
            listeningTask = Task.Run(() =>
            {
                listener = new TcpListener(System.Net.IPAddress.Any, 12345);
                listener.Start();
                txtLog.Invoke((MethodInvoker)(() => txtLog.AppendText("Đang lắng nghe kết nối từ Client 1...\n")));

                while (true)
                {
                    using (TcpClient client = listener.AcceptTcpClient())
                    {
                        txtLog.Invoke((MethodInvoker)(() => txtLog.AppendText("Đã kết nối với Client 1.\n")));
                        ReceiveWeatherInfo(client);
                    }
                }
            });
        }

        private void ReceiveWeatherInfo(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string weatherInfo = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Invoke((MethodInvoker)(() =>
                        {
                            txtWeatherInfo.Text = weatherInfo; // Cập nhật thông tin
                            txtLog.AppendText("Thông tin thời tiết đã nhận: " + weatherInfo + "\n");
                        }));
                    }
                    else
                    {
                        Invoke((MethodInvoker)(() => txtLog.AppendText("Không nhận được dữ liệu từ Client 1.\n")));
                    }
                }
            }
            catch (Exception ex)
            {
                Invoke((MethodInvoker)(() => txtLog.AppendText("Lỗi nhận dữ liệu: " + ex.Message + "\n")));
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dừng lắng nghe khi form đóng lại
            listener?.Stop();
            listeningTask?.Wait();
        }

        private void sendData_Click(object sender, EventArgs e)
        {
                this.Hide(); 
                Form1 form1 = new Form1();
                form1.Show();
            
        }
    }
}

using System;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WeatherAppClient2
{
    public partial class WeatherClient2 : Form
    {
        private HttpListener _httpListener;
        private Task _listenerTask;

        public WeatherClient2()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            string ipAddress = txtIPAddress.Text.Trim();

            if (string.IsNullOrEmpty(ipAddress))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ IP để bắt đầu server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StartServer(ipAddress);
        }

        private void StartServer(string ipAddress)
        {
            try
            {
                _httpListener = new HttpListener();
                string url = $"http://{ipAddress}:8080/";
                _httpListener.Prefixes.Add(url);

                _httpListener.Start();
                lblStatus.Text = $"Server đang chạy trên {url}";

                _listenerTask = Task.Run(() => ListenForRequests());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động server: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ListenForRequests()
        {
            while (_httpListener.IsListening)
            {
                try
                {
                    var context = await _httpListener.GetContextAsync();
                    var request = context.Request;

                    if (request.HttpMethod == "POST")
                    {
                        using (var reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding))
                        {
                            string body = await reader.ReadToEndAsync();
                            this.Invoke((MethodInvoker)delegate
                            {
                                DisplayWeather(body);
                            });
                        }
                    }

                    var response = context.Response;
                    response.StatusCode = 200;
                    response.Close();
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblStatus.Text = $"Lỗi: {ex.Message}";
                    });
                }
            }
        }

        private void DisplayWeather(string weatherData)
        {
            if (string.IsNullOrEmpty(weatherData))
            {
                lblResult.Text = "Không nhận được dữ liệu thời tiết.";
                return;
            }

            try
            {
                var data = JObject.Parse(weatherData);
                string cityName = data["name"]?.ToString();
                string temperature = data["main"]["temp"]?.ToString();
                string humidity = data["main"]["humidity"]?.ToString();
                string description = data["weather"]?[0]?["description"]?.ToString();

                lblResult.Text = $"Thời tiết tại {cityName}:\n" +
                                 $"- Nhiệt độ: {temperature} °C\n" +
                                 $"- Độ ẩm: {humidity}%\n" +
                                 $"- Mô tả: {description}";
            }
            catch (Exception ex)
            {
                lblResult.Text = "Dữ liệu không hợp lệ.";
                MessageBox.Show($"Lỗi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void StopServer()
        {
            try
            {
                if (_httpListener != null && _httpListener.IsListening)
                {
                    _httpListener.Stop();
                    _httpListener.Close();
                    lblStatus.Text = "Server đã dừng.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi dừng server: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Windows Form Designer generated code
        private TextBox txtIPAddress;
        private Button btnStartServer;
        private Button btnStopServer;
        private Label lblStatus;
        private Label lblResult;

        private void InitializeComponent()
        {
            this.Text = "Ứng dụng Dự Báo Thời Tiết - Client 2";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label
            {
                Text = "Client 2 - Nhận dữ liệu thời tiết từ Client 1",
                Location = new Point(50, 10),
                Size = new Size(500, 30),
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblTitle);

            Label lblIP = new Label
            {
                Text = "Địa chỉ IP:",
                Location = new Point(30, 60),
                Size = new Size(100, 30),
                Font = new Font("Arial", 10)
            };
            this.Controls.Add(lblIP);

            txtIPAddress = new TextBox
            {
                Location = new Point(130, 60),
                Size = new Size(300, 30)
            };
            this.Controls.Add(txtIPAddress);

            btnStartServer = new Button
            {
                Text = "Khởi Động Server",
                Location = new Point(450, 60),
                Size = new Size(120, 40),
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.LightGreen
            };
            btnStartServer.Click += new EventHandler(btnStartServer_Click);
            this.Controls.Add(btnStartServer);

            btnStopServer = new Button
            {
                Text = "Dừng Server",
                Location = new Point(450, 120),
                Size = new Size(120, 40),
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.LightCoral
            };
            btnStopServer.Click += new EventHandler(btnStopServer_Click);
            this.Controls.Add(btnStopServer);

            lblStatus = new Label
            {
                Text = "Trạng thái server: Chưa khởi động.",
                Location = new Point(30, 120),
                Size = new Size(400, 30),
                Font = new Font("Arial", 10),
                ForeColor = Color.DarkBlue
            };
            this.Controls.Add(lblStatus);

            lblResult = new Label
            {
                Text = "Dữ liệu thời tiết sẽ hiển thị ở đây.",
                Location = new Point(30, 180),
                Size = new Size(520, 150),
                Font = new Font("Arial", 10),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(lblResult);
        }
        #endregion
    }

    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WeatherClient2());
        }
    }
}

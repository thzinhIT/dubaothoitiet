using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic; 
using System.Net;
using System.Xml;
using System.IO;
using System.Globalization;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;

namespace dubaothoitiet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }


        
        // http://home.openweathermap.org/users/sign_in -- link đăng ký lấy API
        private const string API_KEY = "c7055ce01673bc05bf8af1cb09e60bd2";

       
        private const string CurrentUrl =
            "http://api.openweathermap.org/data/2.5/weather?" +
            "@QUERY@=@LOC@&mode=xml&units=imperial&APPID=" + API_KEY;
        private const string ForecastUrl =
            "http://api.openweathermap.org/data/2.5/forecast?" +
            "@QUERY@=@LOC@&mode=xml&units=imperial&APPID=" + API_KEY;

        
        private string[] QueryCodes = { "q", "zip", "id", };
      

        private void Form1_Load(object sender, EventArgs e)
        {
            cboQuery.Items.Add("City");
            cboQuery.Items.Add("ZIP");
            cboQuery.Items.Add("ID");

            cboQuery.SelectedIndex = 0;
        }

        
        private void btnForecast_Click(object sender, EventArgs e)
        {
            
            string url = ForecastUrl.Replace("@LOC@", txtLocation.Text);
            url = url.Replace("@QUERY@", QueryCodes[cboQuery.SelectedIndex]);

           
            using (WebClient client = new WebClient())
            {
                
                try
                {
                    DisplayForecast(client.DownloadString(url));
                }
                catch (WebException ex)
                {
                    DisplayError(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unknown error\n" + ex.Message);
                }
            }
        }

      
        private void DisplayForecast(string xml)
        {
           
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.LoadXml(xml);

            
            XmlNode loc_node = xml_doc.SelectSingleNode("weatherdata/location");
            txtCity.Text = loc_node.SelectSingleNode("name").InnerText;
            txtCountry.Text = loc_node.SelectSingleNode("country").InnerText;
            XmlNode geo_node = loc_node.SelectSingleNode("location");
            txtLat.Text = geo_node.Attributes["latitude"].Value;
            txtLong.Text = geo_node.Attributes["longitude"].Value;
            txtId.Text = geo_node.Attributes["geobaseid"].Value;

            lvwForecast.Items.Clear();
            char degrees = (char)176;
            
            foreach (XmlNode time_node in xml_doc.SelectNodes("//time"))
            {
               
                DateTime time =
                    DateTime.Parse(time_node.Attributes["from"].Value,
                        null, DateTimeStyles.AssumeUniversal);

              
                XmlNode temp_node = time_node.SelectSingleNode("temperature");
                string temp = temp_node.Attributes["value"].Value;

                ListViewItem item = lvwForecast.Items.Add(time.DayOfWeek.ToString());
                item.SubItems.Add(time.ToShortTimeString());
                item.SubItems.Add(temp + degrees);
            }
        }

      
        private void DisplayError(WebException exception)
        {
            try
            {
                StreamReader reader = new StreamReader(exception.Response.GetResponseStream());
                XmlDocument response_doc = new XmlDocument();
                response_doc.LoadXml(reader.ReadToEnd());
                XmlNode message_node = response_doc.SelectSingleNode("//message");
                MessageBox.Show(message_node.InnerText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown error\n" + ex.Message);
            }
        }

        private void btnInputIP_Click(object sender, EventArgs e)
        {
            string ip1 = Microsoft.VisualBasic.Interaction.InputBox("Nhập địa chỉ IP 1:", "Nhập IP", "192.168.1.1");
            string ip2 = Microsoft.VisualBasic.Interaction.InputBox("Nhập địa chỉ IP 2:", "Nhập IP", "192.168.1.2");

            // Xử lý địa chỉ IP nhập vào
            MessageBox.Show($"Địa chỉ IP 1: {ip1}\nĐịa chỉ IP 2: {ip2}", "Thông tin địa chỉ IP");
        }
        private void lvwForecast_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý khi chỉ mục được chọn thay đổi
            if (lvwForecast.SelectedItems.Count > 0)
            {
                var selectedItem = lvwForecast.SelectedItems[0];
                // Thực hiện các hành động với selectedItem
                MessageBox.Show($"Bạn đã chọn: {selectedItem.Text}");
            }
        }
        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            /*// Xử lý khi nội dung của txtLocation thay đổi
            string locationText = txtLocation.Text;
            // Ví dụ: Hiển thị nội dung trong một MessageBox
            MessageBox.Show($"Nội dung đã thay đổi: {locationText}");*/
        }
        private void btnShowWeather_Click(object sender, EventArgs e)
        {
            // Giả sử bạn đã nhập địa chỉ IP và lưu vào biến ipAddress
            string ipAddress = txtLocation.Text; // hoặc từ nơi bạn lưu địa chỉ IP

            // Gọi hàm để lấy thông tin thời tiết dựa trên ipAddress
            string weatherInfo = GetWeatherInfo(ipAddress);

            // Hiển thị thông tin thời tiết
            MessageBox.Show(weatherInfo, "Thông tin thời tiết");
        }

        private string GetWeatherInfo(string location)
        {
            string url = CurrentUrl.Replace("@LOC@", location);
            url = url.Replace("@QUERY@", QueryCodes[cboQuery.SelectedIndex]);

            using (WebClient client = new WebClient())
            {
                try
                {
                    string response = client.DownloadString(url);
                    return ParseWeatherResponse(response);
                }
                catch (WebException ex)
                {
                    // Xử lý lỗi khi gọi API
                    return "Không thể lấy thông tin thời tiết. Vui lòng kiểm tra lại địa chỉ.";
                }
                catch (Exception ex)
                {
                    return "Lỗi không xác định: " + ex.Message;
                }
            }
        }
        private string ParseWeatherResponse(string xml)
        {
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.LoadXml(xml);

            // Lấy thông tin cần thiết từ XML
            XmlNode temp_node = xml_doc.SelectSingleNode("//temperature");
            string temperature = temp_node?.Attributes["value"]?.Value ?? "N/A";

            XmlNode weather_node = xml_doc.SelectSingleNode("//weather");
            string weatherDescription = weather_node?.Attributes["description"]?.Value ?? "Không có thông tin";

            // Kiểm tra xem temperature và weatherDescription có phải là null không
            if (temperature == null)
            {
                return "Không tìm thấy thông tin nhiệt độ.";
            }

            if (weatherDescription == null)
            {
                return "Không tìm thấy thông tin trạng thái thời tiết.";
            }

            return $"Nhiệt độ: {temperature}°F\nTrạng thái: {weatherDescription}";
        }
        private void btnGetWeather_Click(object sender, EventArgs e)
        {
            // Mã lấy thông tin thời tiết từ API
            // Cập nhật txtWeatherInfo với thông tin thời tiết lấy được
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string receiverIP = txtReceiverID.Text; // Địa chỉ IP của Client 2
            string weatherInfo = txtWeatherInfo.Text; // Thông tin thời tiết

            try
            {
                TcpClient client = new TcpClient(receiverIP, 12345); // Kết nối tới Client 2

                byte[] data = Encoding.UTF8.GetBytes(weatherInfo);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                MessageBox.Show("Thông tin thời tiết đã được gửi.");

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi dữ liệu: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtWeatherInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


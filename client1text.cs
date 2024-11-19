using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WeatherAppClient1
{
    public partial class WeatherClient1 : Form
    {
        public WeatherClient1()
        {
            InitializeComponent();
        }

        private async void btnGetWeather_Click(object sender, EventArgs e)
        {
            string city = txtCity.Text.Trim();
            string country = cmbCountry.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Vui lòng nhập tên thành phố!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(country))
            {
                MessageBox.Show("Vui lòng chọn quốc gia!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblResult.Text = "Đang lấy dữ liệu thời tiết...";
            string weatherData = await GetWeatherDataAsync(city, country);
            DisplayWeather(weatherData);
        }

        private async Task<string> GetWeatherDataAsync(string city, string country)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiKey = "your_api_key_here"; // Thay bằng API key thật
                    string url = $"https://api.openweathermap.org/data/2.5/weather?q={city},{country}&appid={apiKey}&units=metric";

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void DisplayWeather(string weatherData)
        {
            if (string.IsNullOrEmpty(weatherData))
            {
                lblResult.Text = "Không thể lấy dữ liệu thời tiết. Vui lòng thử lại!";
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

        #region Windows Form Designer generated code
        private TextBox txtCity;
        private ComboBox cmbCountry;
        private Button btnGetWeather;
        private Label lblResult;

        private void InitializeComponent()
        {
            this.Text = "Ứng dụng Dự Báo Thời Tiết - Client 1";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label
            {
                Text = "Xem Dự Báo Thời Tiết",
                Location = new Point(150, 10),
                Size = new Size(200, 30),
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblTitle);

            Label lblCity = new Label
            {
                Text = "Thành phố:",
                Location = new Point(30, 60),
                Size = new Size(100, 30),
                Font = new Font("Arial", 10)
            };
            this.Controls.Add(lblCity);

            txtCity = new TextBox
            {
                Location = new Point(130, 60),
                Size = new Size(300, 30)
            };
            this.Controls.Add(txtCity);

            Label lblCountry = new Label
            {
                Text = "Quốc gia:",
                Location = new Point(30, 110),
                Size = new Size(100, 30),
                Font = new Font("Arial", 10)
            };
            this.Controls.Add(lblCountry);

            cmbCountry = new ComboBox
            {
                Location = new Point(130, 110),
                Size = new Size(300, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCountry.Items.AddRange(new string[] { "US", "VN", "JP", "FR", "DE", "IN" });
            this.Controls.Add(cmbCountry);

            btnGetWeather = new Button
            {
                Text = "Xem Dự Báo",
                Location = new Point(180, 160),
                Size = new Size(120, 40),
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.LightBlue
            };
            btnGetWeather.Click += new EventHandler(btnGetWeather_Click);
            this.Controls.Add(btnGetWeather);

            lblResult = new Label
            {
                Text = "",
                Location = new Point(30, 220),
                Size = new Size(420, 120),
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
            Application.Run(new WeatherClient1());
        }
    }
}

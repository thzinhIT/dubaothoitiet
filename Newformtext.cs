using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    public partial class WeatherForm : Form
    {
        public WeatherForm()
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

            string weather = await GetWeatherAsync(city, country);
            if (!string.IsNullOrEmpty(weather))
            {
                DisplayWeather(weather);
            }
            else
            {
                lblDetails.Text = "Không thể lấy dự báo thời tiết!";
            }
        }

        private async Task<string> GetWeatherAsync(string city, string country)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiKey = "your_api_key_here"; // Thay bằng API Key thật
                    string url = $"https://api.openweathermap.org/data/2.5/weather?q={city},{country}&appid={apiKey}&units=metric";

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return result;
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
            try
            {
                var data = JObject.Parse(weatherData);
                string cityName = data["name"]?.ToString();
                string temperature = data["main"]["temp"]?.ToString();
                string humidity = data["main"]["humidity"]?.ToString();
                string description = data["weather"]?[0]?["description"]?.ToString();

                lblDetails.Text = $"Thành phố: {cityName}\n" +
                                  $"Nhiệt độ: {temperature} °C\n" +
                                  $"Độ ẩm: {humidity}%\n" +
                                  $"Mô tả: {description}";
            }
            catch (Exception ex)
            {
                lblDetails.Text = "Lỗi xử lý dữ liệu thời tiết!";
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Windows Form Designer generated code
        private TextBox txtCity;
        private ComboBox cmbCountry;
        private Button btnGetWeather;
        private Label lblDetails;

        private void InitializeComponent()
        {
            this.Text = "Ứng dụng Dự báo Thời tiết Nâng cấp";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label
            {
                Text = "Dự Báo Thời Tiết",
                Location = new Point(150, 10),
                Size = new Size(200, 30),
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblTitle);

            GroupBox groupInput = new GroupBox
            {
                Text = "Nhập thông tin",
                Location = new Point(20, 50),
                Size = new Size(450, 150)
            };
            this.Controls.Add(groupInput);

            Label lblCity = new Label
            {
                Text = "Thành phố:",
                Location = new Point(10, 30),
                Size = new Size(100, 30)
            };
            groupInput.Controls.Add(lblCity);

            txtCity = new TextBox
            {
                Location = new Point(120, 30),
                Size = new Size(300, 30)
            };
            groupInput.Controls.Add(txtCity);

            Label lblCountry = new Label
            {
                Text = "Quốc gia:",
                Location = new Point(10, 70),
                Size = new Size(100, 30)
            };
            groupInput.Controls.Add(lblCountry);

            cmbCountry = new ComboBox
            {
                Location = new Point(120, 70),
                Size = new Size(300, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCountry.Items.AddRange(new string[] { "US", "VN", "JP", "FR", "DE", "IN" });
            groupInput.Controls.Add(cmbCountry);

            btnGetWeather = new Button
            {
                Text = "Lấy Dự Báo",
                Location = new Point(170, 110),
                Size = new Size(100, 30)
            };
            btnGetWeather.Click += new EventHandler(btnGetWeather_Click);
            groupInput.Controls.Add(btnGetWeather);

            GroupBox groupResult = new GroupBox
            {
                Text = "Chi tiết thời tiết",
                Location = new Point(20, 220),
                Size = new Size(450, 120)
            };
            this.Controls.Add(groupResult);

            lblDetails = new Label
            {
                Text = "",
                Location = new Point(10, 20),
                Size = new Size(420, 80),
                Font = new Font("Arial", 10),
                BorderStyle = BorderStyle.FixedSingle
            };
            groupResult.Controls.Add(lblDetails);
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
            Application.Run(new WeatherForm());
        }
    }
}

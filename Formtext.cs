using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Vui lòng nhập tên thành phố!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string weather = await GetWeatherAsync(city);
            lblResult.Text = string.IsNullOrEmpty(weather) 
                ? "Không thể lấy dự báo thời tiết!" 
                : weather;
        }

        private async Task<string> GetWeatherAsync(string city)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiKey = "your_api_key_here"; // Thay bằng API Key thật
                    string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return $"Dự báo thời tiết cho {city}: {result}";
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

        #region Windows Form Designer generated code
        private TextBox txtCity;
        private Button btnGetWeather;
        private Label lblResult;

        private void InitializeComponent()
        {
            this.Text = "Ứng dụng Dự báo Thời tiết";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label
            {
                Text = "Nhập tên thành phố để xem dự báo thời tiết:",
                Location = new Point(10, 10),
                Size = new Size(380, 30),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblTitle);

            txtCity = new TextBox
            {
                Location = new Point(10, 50),
                Size = new Size(250, 30),
                Font = new Font("Arial", 10)
            };
            this.Controls.Add(txtCity);

            btnGetWeather = new Button
            {
                Text = "Lấy Dự Báo",
                Location = new Point(270, 50),
                Size = new Size(100, 30)
            };
            btnGetWeather.Click += new EventHandler(btnGetWeather_Click);
            this.Controls.Add(btnGetWeather);

            lblResult = new Label
            {
                Text = "",
                Location = new Point(10, 100),
                Size = new Size(360, 150),
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
            Application.Run(new WeatherForm());
        }
    }
}

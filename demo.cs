using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class WeatherForecast
{
    static async Task Main(string[] args)
    {
        string apiKey = "YOUR_API_KEY"; // Thay YOUR_API_KEY bằng API key của bạn
        string cityName = "Hanoi"; // Thành phố mà bạn muốn dự báo thời tiết
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric&lang=vi";

        HttpClient client = new HttpClient();

        try
        {
            // Gửi yêu cầu HTTP và nhận kết quả
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync();

            // Phân tích dữ liệu JSON trả về
            var weatherData = JsonConvert.DeserializeObject<WeatherData>(responseData);

            // Hiển thị thông tin dự báo thời tiết
            Console.WriteLine($"Dự báo thời tiết cho thành phố {cityName}:");
            Console.WriteLine($"Nhiệt độ hiện tại: {weatherData.Main.Temp}°C");
            Console.WriteLine($"Cảm giác như: {weatherData.Main.FeelsLike}°C");
            Console.WriteLine($"Độ ẩm: {weatherData.Main.Humidity}%");
            Console.WriteLine($"Tốc độ gió: {weatherData.Wind.Speed} m/s");
            Console.WriteLine($"Trạng thái thời tiết: {weatherData.Weather[0].Description}");
            Console.WriteLine($"Áp suất khí quyển: {weatherData.Main.Pressure} hPa");
            Console.WriteLine($"Mặt trời mọc lúc: {ConvertUnixTimestampToDateTime(weatherData.Sys.Sunrise)}");
            Console.WriteLine($"Mặt trời lặn lúc: {ConvertUnixTimestampToDateTime(weatherData.Sys.Sunset)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }

    // Phương thức chuyển đổi timestamp từ Unix sang DateTime
    static DateTime ConvertUnixTimestampToDateTime(long timestamp)
    {
        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
        return dateTimeOffset.DateTime;
    }
}

public class WeatherData
{
    public MainData Main { get; set; }
    public Weather[] Weather { get; set; }
    public WindData Wind { get; set; }
    public SysData Sys { get; set; }
}

public class MainData
{
    public float Temp { get; set; }
    public float FeelsLike { get; set; }
    public int Humidity { get; set; }
    public int Pressure { get; set; }
}

public class Weather
{
    public string Description { get; set; }
}

public class WindData
{
    public float Speed { get; set; }
}

public class SysData
{
    public long Sunrise { get; set; }
    public long Sunset { get; set; }
}


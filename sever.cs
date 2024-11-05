using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class Server
{
    private TcpListener listener;

    public void StartServer()
    {
        listener = new TcpListener(IPAddress.Any, 8888);
        listener.Start();
        Console.WriteLine("Server is running and waiting for connection...");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine($"Received weather information: {receivedMessage}");

            // Hiển thị thông tin thời tiết lên giao diện
            // Bạn có thể thêm mã ở đây để cập nhật UI với thông tin nhận được
        }
    }
}
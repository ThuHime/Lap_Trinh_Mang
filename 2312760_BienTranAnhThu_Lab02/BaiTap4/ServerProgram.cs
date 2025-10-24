using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace BaiTap4
{
	class ServerProgram
	{
		static void Main(string[] args)
		{
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            serverSocket.Bind(serverEndPoint);
            serverSocket.Listen(10);
            Console.WriteLine("Server dang cho ket noi...");

            // Chấp nhận kết nối
            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine(clientSocket.RemoteEndPoint.ToString());

            // Gửi lời chào "Hello Client"
            byte[] data = Encoding.UTF8.GetBytes("Hello Client");
            clientSocket.Send(data);

            // Giữ cửa sổ không tắt
            Console.ReadLine();

            clientSocket.Close();
            serverSocket.Close();
        }
	}
}

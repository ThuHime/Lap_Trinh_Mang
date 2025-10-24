using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace _2312760_BienTranAnhThu_Lab02
{
	class Program
	{
		static void Main(string[] args)
		{
            // Tạo EndPoint
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);

            // Tạo socket TCP server
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Gán socket với endpoint
            serverSocket.Bind(serverEndPoint);

            // Lắng nghe kết nối đến
            serverSocket.Listen(10);
            Console.WriteLine("Server đang cho ket noi toi cong...");

            // Chấp nhận kết nối client
            Socket clientSocket = serverSocket.Accept();

            // In thông tin client
            EndPoint clientEndPoint = clientSocket.RemoteEndPoint;
            Console.WriteLine(clientEndPoint.ToString());

            //Gửi dữ liệu xuống client
            byte[] buff;
            string hello = "Hello Client";
            buff = Encoding.ASCII.GetBytes(hello);
            clientSocket.Send(buff, 0, buff.Length, SocketFlags.None);
            // Giữ màn hình không bị tắt ngay
            Console.ReadLine();

        }
	}
}

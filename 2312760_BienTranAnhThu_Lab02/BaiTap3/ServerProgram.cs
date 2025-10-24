using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading;

namespace BaiTap3
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

            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine(clientSocket.RemoteEndPoint.ToString());

            // Gửi lời chào cho Client
            string message = "Hello client";
            byte[] data = Encoding.UTF8.GetBytes(message);
            clientSocket.Send(data);

            Console.ReadLine();
            clientSocket.Close();
            serverSocket.Close();
        }
	}
}

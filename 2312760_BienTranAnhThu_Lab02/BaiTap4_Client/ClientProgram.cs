using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace BaiTap4_Client
{
	class ClientProgram
	{
		static void Main(string[] args)
		{
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                Console.WriteLine("Dang ket noi voi server...");
                clientSocket.Connect(serverEndPoint);
                Console.WriteLine("Ket noi thanh cong voi server ...");

                // Nhận và hiển thị lời chào
                byte[] buffer = new byte[1024];
                int bytesReceived = clientSocket.Receive(buffer);
                string message = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                Console.WriteLine(message);

                clientSocket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Khong the ket noi toi Server " + '\n' + ex.Message);
            }

            Console.ReadLine();
        }
    }
}


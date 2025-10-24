using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace BaiTap3_Client
{
	class ClientProgram
	{
		static void Main(string[] args)
		{
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Dang ket noi den server...");
            clientSocket.Connect(serverEndPoint);

            if (clientSocket.Connected)
            {
                Console.WriteLine("Ket noi thanh cong voi server...");

                byte[] buff = new byte[1024];
                int byteReceive = clientSocket.Receive(buff, 0, buff.Length, SocketFlags.None);

                string str = Encoding.UTF8.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);
            }

            clientSocket.Close();
            Console.ReadLine();
        }
	}
}

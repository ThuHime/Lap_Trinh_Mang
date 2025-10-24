using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap6_Server
{
    internal class ServerProgram
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, 5000);

            serverSocket.Bind(serverEndpoint);
            serverSocket.Listen(10);

            Console.WriteLine("Dang cho client ket noi...");

            Socket clientSocket = serverSocket.Accept();
            EndPoint clientEndpoint = clientSocket.RemoteEndPoint;

            string welcomeMsg = "Hello Client";
            byte[] data = Encoding.ASCII.GetBytes(welcomeMsg);
            clientSocket.Send(data);

            byte[] buff = new byte[1024];
            while (true)
            {
                int byteReceive = clientSocket.Receive(buff, 0, buff.Length, SocketFlags.None);

                if (byteReceive == 0)
                {
                    Console.WriteLine("Client đã ngắt kết nối.");
                    break;
                }
                string str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);
                clientSocket.Send(buff, 0, byteReceive, SocketFlags.None);
            }
            clientSocket.Close();
            serverSocket.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap2_CaiTienSever
{
    internal class UDPServer
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverSocket.Bind(serverEndPoint);

            Console.WriteLine("Dang cho Client ket noi toi...");

            byte[] buffer = new byte[1024];
            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                int received = serverSocket.ReceiveFrom(buffer, ref remote);
                string receivedData = Encoding.UTF8.GetString(buffer, 0, received);

                Console.WriteLine($"[{remote}] => {receivedData}");

                if (receivedData.Trim().ToLower() == "exit all")
                {
                    Console.WriteLine("Dong server...");
                    break;
                }
            }

            serverSocket.Close();
        }
    }
}

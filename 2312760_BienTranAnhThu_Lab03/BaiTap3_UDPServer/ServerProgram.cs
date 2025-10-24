using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3_UDPServer
{
    internal class ServerProgram
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, 1234);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            serverSocket.Bind(serverEndpoint);

            Console.WriteLine("Dang cho client ket noi...");

            EndPoint clientEndpoint = new IPEndPoint(IPAddress.Any, 0);

            byte[] buffer = new byte[1024];
            int receivedByte;

            while (true)
            {
                buffer = new byte[1024];
                receivedByte = serverSocket.ReceiveFrom(buffer, ref clientEndpoint);

                string dataStr = Encoding.ASCII.GetString(buffer, 0, receivedByte);

                Console.WriteLine("Da ket noi voi Client: " + clientEndpoint);
                Console.WriteLine(dataStr);
            }
        }
    }
}


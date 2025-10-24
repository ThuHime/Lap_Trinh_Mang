using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap1_UDPClient
{
    internal class UDPClient
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

            string message = "Hello Server";
            byte[] buffer = Encoding.UTF8.GetBytes(message);

            Console.WriteLine("Dang goi cau chao len server...");
            clientSocket.SendTo(buffer, serverEndPoint);
            Console.WriteLine("Da goi cau chao len server...");

            clientSocket.Close();
            Console.ReadKey();
        }
    }
}

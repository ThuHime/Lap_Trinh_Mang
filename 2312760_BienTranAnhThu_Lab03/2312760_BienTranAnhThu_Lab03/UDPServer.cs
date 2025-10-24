using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace _2312760_BienTranAnhThu_Lab03
{
    internal class UDPServer
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverSocket.Bind(serverEndPoint);

            Console.WriteLine("Dang cho client ket noi toi...");

            byte[] buffer = new byte[1024];
            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            int received = serverSocket.ReceiveFrom(buffer, ref remote);
            string receivedData = Encoding.UTF8.GetString(buffer, 0, received);

            Console.WriteLine($"Da ket noi voi client: {remote.ToString()}");
            Console.WriteLine(receivedData);

            Console.WriteLine("Da dong ket noi voi client");
            serverSocket.Close();
            Console.ReadKey();
        }
    }
}

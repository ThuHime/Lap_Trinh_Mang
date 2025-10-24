using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3_UDPClient
{
    internal class ClientProgram
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 1234);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {
                Console.Write("Nhap du lieu can gui: ");
                string str = Console.ReadLine();

                if (str.Equals("exit")) break;

                byte[] data = Encoding.ASCII.GetBytes(str);

                serverSocket.SendTo(data, data.Length, SocketFlags.None, serverEndpoint);
                Console.WriteLine("Da goi cau chao len Server");

                Console.WriteLine();
            }

            Console.WriteLine("Da thoat chuong trinh client");
            Console.ReadLine();
            serverSocket.Close();
        }
    }
}

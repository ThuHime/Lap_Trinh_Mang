using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap5_Server
{
    internal class ServerProgram
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint local = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

            serverSocket.Bind(local);
            Console.WriteLine("Dang cho client goi thong diep...");

            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            byte[] buff = new byte[1024];

            int byteReceive = serverSocket.ReceiveFrom(buff, 0, buff.Length, SocketFlags.None, ref remote);
            string hello = Encoding.ASCII.GetString(buff, 0, byteReceive);
            Console.WriteLine(hello);

            for (int i = 1; i <= 5; i++)
            {
                byteReceive = serverSocket.ReceiveFrom(buff, 0, buff.Length, SocketFlags.None, ref remote);
                string str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);
            }

            serverSocket.Close();
            Console.ReadKey();
        }
    }
}

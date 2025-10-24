using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BaiTap5_Client
{
    internal class ClientProgram
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint remote = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

            Console.WriteLine("Dang goi cau chao len Server...");

            byte[] buff = Encoding.ASCII.GetBytes("Hello Server");
            clientSocket.SendTo(buff, 0, buff.Length, SocketFlags.None, remote);

            for (int i = 1; i <= 5; i++)
            {
                string message = "Thong Diep " + i.ToString();
                buff = Encoding.ASCII.GetBytes(message);
                clientSocket.SendTo(buff, 0, buff.Length, SocketFlags.None, remote);
                Thread.Sleep(500); 
            }
            Console.WriteLine("Da goi cau chao len Server...");
            clientSocket.Close();
            Console.ReadKey();
        }
    }
}

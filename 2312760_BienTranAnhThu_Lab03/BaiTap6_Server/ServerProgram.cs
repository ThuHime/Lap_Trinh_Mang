using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap6_Server
{
    internal class ServerProgram
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 5000);
            server.Bind(ipep);

            Console.WriteLine("Dang cho Client ket noi den...");

            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = new byte[1024];
            bool firstMsg = true;

            while (true)
            {
                if (firstMsg)
                {
                    Console.WriteLine("Thong diep duoc nhan tu " + remote.ToString() + ":");
                    firstMsg = false;
                }
                int recv = server.ReceiveFrom(data, ref remote);
                string text = Encoding.ASCII.GetString(data, 0, recv);

                

                Console.WriteLine(text);

                string response = "xin chao, toi la Anh Thu";
                byte[] resp = Encoding.ASCII.GetBytes(response);
                server.SendTo(resp, remote);
            }
        }
    }
}


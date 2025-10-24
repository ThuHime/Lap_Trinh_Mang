using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap2_CaiTienClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

            Console.WriteLine("Client dang chay. Go 'exit' de thoat hoac 'exit all' de dong ca client va server");

            while (true)
            {
                Console.Write("Nhap: ");
                string message = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                clientSocket.SendTo(buffer, serverEndPoint);

                if (message.Trim().ToLower() == "exit" || message.Trim().ToLower() == "exit all")
                {
                    Console.WriteLine("Da gui lenh thoat. Dong client...");
                    break;
                }
            }

            clientSocket.Close();
        }
    }
}

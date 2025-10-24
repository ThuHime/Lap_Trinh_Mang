using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap6_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint remote = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            EndPoint tmpRemote = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("Hello Client");

            bool firstMsg = true;
            int i = 10; 

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exit") break;

                byte[] sendData = Encoding.ASCII.GetBytes(input);
                client.SendTo(sendData, remote);

                byte[] buffer = new byte[i];

                try
                {
                    int recv = client.ReceiveFrom(buffer, ref tmpRemote);
                    string response = Encoding.ASCII.GetString(buffer, 0, recv);

                    if (firstMsg)
                    {
                        Console.WriteLine("Thong diep duoc nhan tu " + tmpRemote.ToString() + ":");
                        firstMsg = false;
                    }

                    Console.WriteLine(response);
                }
                catch (SocketException)
                {
                    Console.WriteLine("Canh bao: du lieu bi mat, hay thu lai");
                    i += 10; 
                }
            }

            client.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap7_Client
{
    internal class Program
    {
        static byte[] data;

        private static int SndRcvData(Socket s, byte[] message, EndPoint rmtdevice)
        {
            int recv;
            int retry = 0;
            EndPoint Remote = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                Console.WriteLine("Truyen lai lan thu: #{0}", retry);
                if (retry == 0)
                {
                    Console.WriteLine("Hello Client");
                }
                try
                {
                    s.SendTo(message, message.Length, SocketFlags.None, rmtdevice);
                    data = new byte[1024];
                    recv = s.ReceiveFrom(data, ref Remote);
                }
                catch (SocketException)
                {
                    recv = 0;
                }

                if (recv > 0)
                {
                    return recv;
                }
                else
                {
                    retry++;
                    if (retry > 4)
                        return 0;
                }
            }
        }
        static void Main(string[] args)
        {
            string input, stringData;
            int recv;

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            int sockopt = (int)server.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout);
            Console.WriteLine("Gia tri timeout mac dinh: {0}", sockopt);

            server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);

            sockopt = (int)server.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout);
            Console.WriteLine("Gia tri timeout moi: {0}", sockopt);

            string welcome = "Xin chao Server";
            data = Encoding.ASCII.GetBytes(welcome);
            recv = SndRcvData(server, data, ipep);

            if (recv > 0)
            {
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine(stringData);
            }
            else
            {
                Console.WriteLine("Khong the lien lac voi thiet bi o xa");
                return;
            }

            while (true)
            {
                input = Console.ReadLine();
                if (input == "exit") break;

                recv = SndRcvData(server, Encoding.ASCII.GetBytes(input), ipep);
                if (recv > 0)
                {
                    stringData = Encoding.ASCII.GetString(data, 0, recv);
                    Console.WriteLine(stringData);
                }
                else
                {
                    Console.WriteLine("Khong nhan duoc cau tra loi");
                }
            }

            Console.WriteLine("Dang dong client");
            server.Close();
        }
    }
}

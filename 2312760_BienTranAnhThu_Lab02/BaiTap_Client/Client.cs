using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap_Client
{
    internal class Client
    {
        static void Main(string[] args)
        {
            IPEndPoint clientrEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(clientrEndpoint);
                Console.WriteLine("Da ket noi den server...");
                Console.WriteLine("Nhap phep tinh hoac 'exit' de thoat.");

                while (true)
                {
                    Console.Write("Phep tinh: ");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "exit")
                    {
                        byte[] exitMsg = Encoding.UTF8.GetBytes("exit");
                        clientSocket.Send(exitMsg);
                        break;
                    }

                    byte[] data = Encoding.UTF8.GetBytes(input);
                    clientSocket.Send(data);

                    byte[] buffer = new byte[1024];
                    int byteReceive = clientSocket.Receive(buffer);
                    string result = Encoding.UTF8.GetString(buffer, 0, byteReceive);

                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
            Console.ReadKey();
            clientSocket.Close();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap5_Server
{
    internal class ServerProgram
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            serverSocket.Bind(ipEndPoint);
            serverSocket.Listen(10);

            Console.WriteLine("Server dang cho ket noi...");

            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine("Client da ket noi!");

            byte[] buff = new byte[1024];

            while (true)
            {
                int byteReceive = clientSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                if (byteReceive == 0)
                {
                    Console.WriteLine("Client đã ngắt kết nối (trả về 0 byte).");
                    break;
                }
                string str = Encoding.ASCII.GetString(buff, 0, byteReceive);

                if (str.ToLower() == "exit")
                {
                    Console.WriteLine("Client da ngat ket noi.");
                    break;
                }

                Console.WriteLine("Du lieu nhan duoc tu client: " + str);

                // Phản hồi lại cho client
                string response =  str;
                byte[] sendBuff = Encoding.ASCII.GetBytes(response);
                clientSocket.Send(sendBuff, 0, sendBuff.Length, SocketFlags.None);
            }

            clientSocket.Close();
            serverSocket.Close();
        }
    }
}

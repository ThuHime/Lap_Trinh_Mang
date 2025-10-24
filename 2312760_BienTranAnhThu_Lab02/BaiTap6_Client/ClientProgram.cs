using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap6_Client
{
    internal class ClientProgram
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Dang ket noi voi server...");

            try
            {
                clientSocket.Connect(serverEndPoint);
                Console.WriteLine("Ket noi thanh cong voi server...");
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Khong the ket noi toi server: " + ex.Message);
                Console.ReadKey();
                return;
            }
            byte[] buff = new byte[1024];
            int byteReceive = clientSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
            string serverMessage = Encoding.ASCII.GetString(buff, 0, byteReceive);
            Console.WriteLine(serverMessage);

            while (true)
            {
                Console.Write("Nhap du lieu gui toi server (hoac exit de thoat): ");
                string str = Console.ReadLine();

                if (str.ToLower() == "exit")
                    break;

                byte[] sendBuff = Encoding.ASCII.GetBytes(str);
                clientSocket.Send(sendBuff, 0, sendBuff.Length, SocketFlags.None);

                byteReceive = clientSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                string response = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(response);
            }
            clientSocket.Close();
        }
    }
}

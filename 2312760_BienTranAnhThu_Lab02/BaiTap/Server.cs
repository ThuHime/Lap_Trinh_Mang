using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap
{
    internal class Server
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            serverSocket.Bind(serverEndpoint);
            serverSocket.Listen(10);

            Console.WriteLine("Server dang cho ket noi...");
            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine("Ket noi thanh cong!");
            try
            {
                while (true)
                {
                    byte[] buff = new byte[1024];
                    int byteReceive = clientSocket.Receive(buff);
                    string request = Encoding.UTF8.GetString(buff, 0, byteReceive);

                    Console.WriteLine("Yeu cau tu client: " + request);

                    string response = TinhToan(request);
                    byte[] data = Encoding.UTF8.GetBytes(response);
                    clientSocket.Send(data);
                }
            }
            catch
            {
                Console.WriteLine("Client da ngat ket noi! Thoat chuong trinh!");
            }
            Console.ReadKey();
            clientSocket.Close();
            serverSocket.Close();
        }
        static string TinhToan(string expression)
        {
            try
            {
                expression = expression.Replace(" ", "");

                double result = 0;
                if (expression.Contains("+"))
                {
                    var parts = expression.Split('+');
                    result = double.Parse(parts[0]) + double.Parse(parts[1]);
                }
                else if (expression.Contains("-"))
                {
                    var parts = expression.Split('-');
                    result = double.Parse(parts[0]) - double.Parse(parts[1]);
                }
                else if (expression.Contains("*"))
                {
                    var parts = expression.Split('*');
                    result = double.Parse(parts[0]) * double.Parse(parts[1]);
                }
                else if (expression.Contains("/"))
                {
                    var parts = expression.Split('/');
                    double divisor = double.Parse(parts[1]);
                    if (divisor == 0)
                        return "Loi: chia cho 0";
                    result = double.Parse(parts[0]) / divisor;
                }
                else
                {
                    return "Phep tinh khong hop le!";
                }

                return "Ket qua: " + result;
            }
            catch
            {
                return "Loi khi tinh toan!";
            }
        }
    }
}

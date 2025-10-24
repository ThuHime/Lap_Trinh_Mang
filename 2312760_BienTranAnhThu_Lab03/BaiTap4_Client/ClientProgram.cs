using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap4_Client
{
    internal class ClientProgram
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint remote = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

            Console.WriteLine("Dang goi cau chao len Server...");

            clientSocket.Connect(remote);
            Console.WriteLine("Da ket noi den Server...");

            string message = "Hello Server";
            byte[] sendData = Encoding.ASCII.GetBytes(message);
            clientSocket.Send(sendData);

            byte[] recv = new byte[1024];
            int bytesReceived = clientSocket.Receive(recv);
            string response = Encoding.ASCII.GetString(recv, 0, bytesReceived);
            Console.WriteLine(response);

            clientSocket.Close();
            Console.ReadKey();
        }
    }
}

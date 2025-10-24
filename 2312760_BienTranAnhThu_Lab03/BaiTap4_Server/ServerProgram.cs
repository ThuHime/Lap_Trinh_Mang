using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap4_Server
{
    internal class ServerProgram
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            serverSocket.Bind(endPoint);
            serverSocket.Listen(10); 

            Console.WriteLine("Dang cho client ket noi toi...");

            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine("Da ket noi voi Client: " + clientSocket.RemoteEndPoint.ToString());

            byte[] recv = new byte[1024];
            int bytesReceived = clientSocket.Receive(recv);
            string data = Encoding.ASCII.GetString(recv, 0, bytesReceived);
            Console.WriteLine(data);

            string reply = "Hello\nToi la Anh Thu";
            byte[] sendData = Encoding.ASCII.GetBytes(reply);
            clientSocket.Send(sendData);

            serverSocket.Close();
            Console.ReadKey();  
        }
    }
}

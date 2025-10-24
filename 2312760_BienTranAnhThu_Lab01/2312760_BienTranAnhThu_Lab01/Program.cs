using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics.Contracts;

namespace _2312760_BienTranAnhThu_Lab01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (String arg in args)
            {
                {
                    Console.WriteLine("Phan giai ten mien: " + arg);
                    Console.WriteLine("Resolve for: "+arg);
                    GetHostInfo(arg);
                }
            }
            Console.ReadKey();
        }
        static void GetHostInfo(string host)
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(host);
                Console.WriteLine("Ten mien: " + (hostInfo.HostName.StartsWith("www.")?hostInfo.HostName.Substring(4):hostInfo.HostName));
                Console.Write("Dia chi IP: ");
                foreach (IPAddress ipaddr in hostInfo.AddressList)
                    Console.Write(ipaddr.ToString() + "");
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Khong phan giai duoc ten mien:" + host + "\n");
            }
        }
    }
}

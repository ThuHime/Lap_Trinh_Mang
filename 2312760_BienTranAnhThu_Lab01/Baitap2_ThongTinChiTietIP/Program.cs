using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Baitap2_ThongTinChiTietIP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
                if (ni.OperationalStatus == OperationalStatus.Up)
                    PrintInfo(ni);
            Console.ReadKey();
        }
        static void PrintInfo(NetworkInterface ni)
        {
            var props=ni.GetIPProperties();
            Console.WriteLine($"Interface:{ni.Name}");
            foreach (var ip in props.UnicastAddresses)
                if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                    Console.WriteLine($"  IP: {ip.Address}, Subnet Mask: {ip.IPv4Mask}");
            foreach (var gw in props.GatewayAddresses)
                if (gw.Address.AddressFamily == AddressFamily.InterNetwork)
                    Console.WriteLine($"  Gateway: {gw.Address}");
            Console.WriteLine(new string('-', 30));
        }
    }
}

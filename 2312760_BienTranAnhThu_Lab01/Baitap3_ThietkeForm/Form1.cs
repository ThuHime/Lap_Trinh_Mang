using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;


namespace Baitap3_ThietkeForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            string host = txtDomain.Text.Trim();
            lsbDNSResult.Items.Clear();

            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(host);
                lsbDNSResult.Items.Add("Tên miền: " + (hostInfo.HostName.StartsWith("www.") ? hostInfo.HostName.Substring(4) : hostInfo.HostName));
                string ipList = string.Join(", ", hostInfo.AddressList.Select(ip => ip.ToString()));
                lsbDNSResult.Items.Add("Địa chỉ IP:" + ipList);
            }
            catch
            {
                lsbDNSResult.Items.Add("Không phân giải được tên miền: " + host);
            }
        }
        private void HienThiThongTinIP()
        {
            lbResult.Items.Clear(); // Xóa cũ

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Bỏ qua các interface không hoạt động hoặc ảo
                if (ni.OperationalStatus != OperationalStatus.Up ||
                    ni.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                    continue;

                lbResult.Items.Add("Interface: " + ni.Name);

                IPInterfaceProperties ipProps = ni.GetIPProperties();

                // Địa chỉ IP và subnet mask
                foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork) // IPv4
                    {
                        lbResult.Items.Add("Địa chỉ IP: " + ip.Address);
                        lbResult.Items.Add("Subnet Mask: " + ip.IPv4Mask);
                    }
                }

                // Default Gateway
                foreach (GatewayIPAddressInformation gateway in ipProps.GatewayAddresses)
                {
                    if (gateway.Address.AddressFamily == AddressFamily.InterNetwork)
                        lbResult.Items.Add("Default Gateway: " + gateway.Address);
                }

                // DNS Server
                lbResult.Items.Add("DNS Server:");
                foreach (IPAddress dns in ipProps.DnsAddresses)
                {
                    if (dns.AddressFamily == AddressFamily.InterNetwork)
                        lbResult.Items.Add(" - " + dns.ToString());
                }

                lbResult.Items.Add("===================================");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiThongTinIP();
        }
        private string GetLocalIPv4()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return null;
        }
    }
}

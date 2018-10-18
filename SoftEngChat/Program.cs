using SoftEngChat.Model.SSLCommunication;
using System;
using System.Net;
using System.Net.Sockets;

namespace SoftEngChat
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            //Starting the server that runs the whole program
            IPAddress addre = IPAddress.Parse("127.0.0.1");
            SSLServer server = new SSLServer(addre, 5300);
        }


        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}

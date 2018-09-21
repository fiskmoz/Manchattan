using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using SoftEngChat.Model.SSLCommunication;

namespace SoftEngChat
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Starting the server that runs the whole program
            SSLServer server = new SSLServer(IPAddress.Loopback, 5300);
        }
    }
}

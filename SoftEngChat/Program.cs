using SoftEngChat.Model.SSLCommunication;
using System.Net;

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

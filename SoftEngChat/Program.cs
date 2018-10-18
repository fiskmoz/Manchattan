using SoftEngChat.Model.SSLCommunication;
using System.Net;

namespace SoftEngChat
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Starting the server that runs the whole program
            IPAddress addre = IPAddress.Parse("10.220.1.105");
            SSLServer server = new SSLServer(addre, 5300);
        }
    }
}

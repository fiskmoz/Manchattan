using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftEngChatClient
{
    class TCPNetwork
    {
        public TcpClient mainClient;

        public TCPNetwork()
        {
            InitializeTCPConnection();
        }

        public void InitializeTCPConnection()
        {
            mainClient = new TcpClient();
            try
            {
                mainClient.Connect("127.0.0.1", 5300);
            }
            catch (Exception e)
            {
                // NOTHING: for now
            }
        }

        public void SendMessageToServer(string str, int v)
        {
            var stream = mainClient.GetStream();
            stream.Write(Encoding.ASCII.GetBytes(str), 0, v);
        }
    }
}

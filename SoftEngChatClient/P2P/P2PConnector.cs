using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient.P2P
{
    class P2PConnector
    {
        public P2PConnector() { }

        public NetworkStream ReceiveConnection(string ip, int port)
        {
            IPAddress localAdress = IPAddress.Parse(ip);
            TcpListener listener = new TcpListener(localAdress, port);

            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            //---get the incoming data through a network stream---
            NetworkStream netStream = client.GetStream();

            return netStream;
        }

        public NetworkStream Connect(string ip, int port)
        {
            TcpClient client = new TcpClient(ip, port);
            NetworkStream netStream = client.GetStream();
            return netStream;
        }
    }
}

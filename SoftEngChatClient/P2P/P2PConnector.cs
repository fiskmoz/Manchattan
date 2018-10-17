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
        private string ipAddress;
        private int portNumber;
        public P2PConnector(string ip, int port)
        {
            ipAddress = ip;
            portNumber = port;
        }

        public NetworkStream ReceiveConnection()
        {
            IPAddress localAdress = IPAddress.Parse(ipAddress);
            TcpListener listener = new TcpListener(localAdress, portNumber);

            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            //---get the incoming data through a network stream---
            NetworkStream netStream = client.GetStream();

            return netStream;
        }

        public NetworkStream Connect()
        {
            TcpClient client = new TcpClient(ipAddress, portNumber);
            NetworkStream netStream = client.GetStream();
            return netStream;
        }
    }
}

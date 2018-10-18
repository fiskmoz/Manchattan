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

		public event EventHandler IncommingConnection;

        public void ReceiveConnection(object sender, EventArgs e)
        {
			P2PIncommingConnection args = (P2PIncommingConnection)e;
			IPAddress localAdress = IPAddress.Parse(args.ip);
            TcpListener listener = new TcpListener(localAdress, args.port);
            

            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            //---get the incoming data through a network stream---
            NetworkStream netStream = client.GetStream();

			IncommingConnection(this, new IncommingP2PConnection(args.sender, netStream, args.key));
        }

        public NetworkStream Connect(string ip, int port)
        {
            TcpClient client = new TcpClient(ip, port);
            NetworkStream netStream = client.GetStream();
            return netStream;
        }

		internal void Subscribe(Model.Messagehandler messageHandler)
		{
			messageHandler.IncommingP2P += new EventHandler(ReceiveConnection);
		}
	}

	class IncommingP2PConnection: EventArgs
	{
		public string sender { get; private set; }
		public NetworkStream netStream { get; private set; }
        public string key { get; private set; }
		public IncommingP2PConnection(string sender, NetworkStream netStream, string key)
		{
			this.sender = sender;
			this.netStream = netStream;
            this.key = key;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SoftEngChatClient.MessageHandling;

namespace SoftEngChatClient.P2P
{
    class P2PListener: StreamListener
    {
        private NetworkStream netStream;
		private bool stopListen;
		private Thread listeningThread;
		private string username;

        public P2PListener(NetworkStream netStream, string username)
        {
			this.username = username;
            this.netStream = netStream;
            stopListen = false;
        }

        public void StopListen()
        {
            stopListen = true;
        }

		public void StartListen()
        {
            listeningThread = new Thread(Listen);
            listeningThread.Start();
        }

        public void Listen()
        {
            byte[] buffer = new byte[2048];
			int bytesRead = 0;
			bool readFail = false;
			string incomming = null;
			while (true)
            {
				//---read incoming stream---
				try{

					bytesRead = netStream.Read(buffer, 0, 2048);
				}
				catch(Exception e)
				{
					readFail = true;
					netStream.Close();
					incomming = "5:1:" + username;
					stopListen = true;
				}

				//---convert the data received into a string---
				if(!readFail)
					incomming = Encoding.UTF8.GetString(buffer, 0, bytesRead);

				RaiseEvent(incomming);
                if (stopListen) break;
            }
        }

		public event EventHandler IncommingMessage;
		public void RaiseEvent(string incomming)
		{
			IncommingMessage message = new IncommingMessage(incomming);
			message.Message = incomming;
			IncommingMessage(this, message);
		}
	}
}

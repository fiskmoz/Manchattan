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
        NetworkStream netStream;
        bool stopListen;
        Thread listeningThread;

        public P2PListener(NetworkStream netStream)
        {
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

            while (true)
            {
                //---read incoming stream---
                int bytesRead = netStream.Read(buffer, 0, 2048);

                //---convert the data received into a string---
                string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
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

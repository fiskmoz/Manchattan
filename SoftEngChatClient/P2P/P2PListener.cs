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
        private ClientCrypto cc;

        public P2PListener(NetworkStream netStream, byte[] key)
        {
            this.netStream = netStream;
            cc = new ClientCrypto();
            cc.SetNewKey(key);
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
                string incomming = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                string[] splitString = incomming.Split(':');
                if (splitString[0] == "2")
                {
                    int NumberChars = splitString[3].Length;
                    byte[] messageBytes = new byte[NumberChars / 2];
                    for (int i = 0; i < NumberChars; i += 2)
                        messageBytes[i / 2] = System.Convert.ToByte(splitString[3].Substring(i, 2), 16);
                    splitString[3] = cc.DecryptBytes(messageBytes);
                    incomming = string.Join(":", splitString);
                }
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

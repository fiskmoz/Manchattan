using System;
using System.Collections.Generic;
using System.IO;
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
		private string username;
		private int BUFFERSIZE = 2048;
		
        public P2PListener(NetworkStream netStream, string username, byte[] key)
        {
			this.username = username;
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
            byte[] buffer = new byte[BUFFERSIZE];
			int bytesRead = 0;
			bool readFail = false;
			string incomming = null;
			while (!stopListen)
            {
				//---read incoming stream---
				try{

					bytesRead = netStream.Read(buffer, 0, BUFFERSIZE);
				}
				catch(Exception e)
				{
					readFail = true;
					netStream.Close();
					incomming = "5:1:" + username;
					stopListen = true;
				}

				//---convert the data received into a string---
				if (!readFail)
				{
					incomming = Encoding.UTF8.GetString(buffer, 0, bytesRead);
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
				}
               
                RaiseEvent(incomming);
                if (stopListen) break;
            }
			listeningThread.Join();
		}

		public event EventHandler IncommingMessage;
		public void RaiseEvent(string incomming)
		{
			IncommingMessage message = new IncommingMessage(incomming);
			message.Message = incomming;
			IncommingMessage(this, message);
		}

		internal byte[] StartFileListener()
		{
			byte[] output = null;
			listeningThread = new Thread(
				() =>
				{
					output = ListenForFile();
				});
			listeningThread.Start();
			listeningThread.Join();

			return output;
		}

		private byte[] ListenForFile()
		{
			int bytesRead = 0;
			int allBytesRead = 0;

			byte[] length = new byte[4];
			bytesRead = netStream.Read(length, 0, 4);
			int dataLength = BitConverter.ToInt32(length, 0);

			// Read the data
			int bytesLeft = dataLength;
			byte[] data = new byte[dataLength];

			while (bytesLeft > 0)
			{
				int nextPacketSize = (bytesLeft > BUFFERSIZE) ? BUFFERSIZE : bytesLeft;

				bytesRead = netStream.Read(data, allBytesRead, nextPacketSize);
				allBytesRead += bytesRead;
				bytesLeft -= bytesRead;

			}
			return data;
		}
	}
}

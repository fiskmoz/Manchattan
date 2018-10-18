using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SoftEngChatClient.MessageHandling;

namespace SoftEngChatClient.Model.SSLCommunication
{
	class SSLListener : StreamListener
	{
		public SslStream stream;
		private Thread listeningThread;
		private bool stopListen;

		public SSLListener(SslStream stream)
		{
			this.stream = stream;
			stopListen = false;
		//	listeningThread = new Thread(Listen);
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

		//Start to listen for incomming messages.
		//Raises event when message arrives, if error: event message == 0
		public void Listen()
		{
            byte[] incommingMessage = new byte[2048];
            StringBuilder messageData = new StringBuilder();
            //stream.ReadTimeout = 100;

            while (true)
            {
                System.Threading.Thread.Sleep(50);
                int bytesRead = 0;
                try
                {
                    bytesRead = stream.Read(incommingMessage, 0, incommingMessage.Length);
                }
                catch (Exception)
                { }
                if (bytesRead > 0)
                {
                    string message = Encoding.UTF8.GetString(incommingMessage, 0, bytesRead);
                    if (!message.Contains("\0") || message.Length > 1)
                    {
                        messageData.Append(message);
                        if (messageData.ToString().Length > 1)
                        {
                            RaiseEvent(messageData.ToString());
                            messageData.Clear();
                        }
                            
                        message = null;
                        //RaiseEvent(message);
                    }

                }
                if (stopListen) continue;
            }
        }

		//Read message from SSL stream.
		//IN: SSL stream, buffer.
		//OUT: fills buffer; Incomming message (byte[])
		private void ReadMessage(SslStream stream, byte[] buffer)
		{
			try
			{
				int bytesRead = stream.Read(buffer, 0, buffer.Length);
			}
			catch (Exception)
			{
				RaiseEvent(null);
				buffer = null;
			}
		}

		//Eventhandling
		//public delegate void EventHandler(Object sender, IncommingMessage eventArgs);
		public event EventHandler IncommingMessage;

		public void RaiseEvent(string incomming)
		{
			IncommingMessage message = new IncommingMessage(incomming);
			message.Message = incomming;
			IncommingMessage(this, message);
		}
	}


}

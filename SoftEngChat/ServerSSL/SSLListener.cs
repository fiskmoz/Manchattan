using System;
using System.Net.Security;
using System.Text;
using System.Threading;

namespace SoftEngChat.Model.SSLCommunication
{
    class SSLListener
	{
		private SslStream stream;
		private Thread listeningThread;
		private bool stopListen;

		//Listens to the stream connected.
		//Raises IncommingMessage event when message arrives.
		//Wakes a new thread when listening is started.
		public SSLListener(SslStream stream)
		{
			this.stream = stream;
			stopListen = false;
			listeningThread = new Thread(Listen);
            listeningThread.Start();
        }


		public void StopListen()
		{
			stopListen = true;
		}

		//Start to listen for incomming messages.
		//Raises event when message arrives, if error: event message == 0
		private void Listen()
		{
			byte[] incommingMessage = new byte[2048];
            StringBuilder messageData = new StringBuilder();
            //stream.ReadTimeout = 100;

            while (true)
			{
                int bytesRead = 0;
                try
                {
                    bytesRead = stream.Read(incommingMessage, 0, incommingMessage.Length);
                }
                catch(Exception)
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
                if (stopListen) break;
				Thread.Sleep(250);
            }
		}



		//Eventhandling
		public delegate void EventHandler(Object sender, IncommingMessage eventArgs);
		public event EventHandler IncommingMessage;
		public void RaiseEvent(string incomming)
		{
			IncommingMessage message = new IncommingMessage();
			message.Message = incomming;
			IncommingMessage(this, message);
		}
	}

	//IncommingMessage Event argument declaration.
	class IncommingMessage : EventArgs
	{
		public string Message { get; set; }
	}
}

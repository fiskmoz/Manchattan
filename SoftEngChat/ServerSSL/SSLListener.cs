using System;
using System.Collections.Generic;
using System.Linq;
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

		//Kills listening thread.
		public void StopListen()
		{
			stopListen = true;
		}

		//Start to listen for incomming messages.
		//Raises event when message arrives, if error: event message == 0
		private void Listen()
		{
			byte[] incommingMessage = new byte[2048];

			while (true)
			{
                int bytesRead = 0;
                try
                {
                    bytesRead = stream.Read(incommingMessage, 0, incommingMessage.Length);
                    if (bytesRead == 0) incommingMessage = null;
                }
                catch(Exception e )
                {
                    incommingMessage = null;
                }
                if(bytesRead > 0)
                {
                    if (incommingMessage != null)
                    {
                        RaiseEvent(incommingMessage);
                    }
                }
				if (stopListen) continue;
			}
		}

		//Eventhandling
		public delegate void EventHandler(Object sender, IncommingMessage eventArgs);
		public event EventHandler IncommingMessage;

		//Raises IncommingMessage event.
		//IN: Byte array containing the message.
		public void RaiseEvent(byte[] incomming)
		{
			IncommingMessage message = new IncommingMessage();
			message.Message = incomming;
			IncommingMessage(this, message);
		}
	}

	//IncommingMessage Event argument declaration. Needed to send let EventHandler catch message.
	class IncommingMessage : EventArgs
	{
		public byte[] Message { get; set; }
	}
}

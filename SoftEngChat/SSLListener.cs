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
				ReadMessage(stream, incommingMessage);
				if (incommingMessage != null)
					RaiseEvent(incommingMessage);
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
#pragma warning disable CS0168 // Variable is declared but never used
			catch (Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
			{
				RaiseEvent(null);
				buffer = null;
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

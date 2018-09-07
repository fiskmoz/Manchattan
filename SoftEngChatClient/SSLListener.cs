using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftEngChatClient.Model.SSLCommunication
{
	class SSLListener
	{
		private SslStream stream;
		private Thread listeningThread;
		private bool stopListen;

		public SSLListener(SslStream stream)
		{
			this.stream = stream;
			stopListen = false;
			listeningThread = new Thread(StartListen);
		}

		public void StopListen()
		{
			stopListen = true;
		}

		public void StartListen()
		{
			Thread listeningThread = new Thread(StartListen);
			listeningThread.Start();
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
			catch (Exception e)
			{
				RaiseEvent(null);
				buffer = null;
			}
		}

		//Eventhandling
		public delegate void EventHandler(Object sender, IncommingMessage eventArgs);
		public static event EventHandler IncommingMessage;

		public void RaiseEvent(byte[] incomming)
		{
			IncommingMessage message = new IncommingMessage();
			message.Message = incomming;
			IncommingMessage(this, message);
		}
	}

	class IncommingMessage : EventArgs
	{
		public byte[] Message { get; set; }
	}
}

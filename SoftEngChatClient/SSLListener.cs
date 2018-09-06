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
		public SSLListener(SslStream stream)
		{
			Thread listeningThread = new Thread(StartListen);
			listeningThread.Start(stream);
		}

		//Start to listen for incomming messages.
		//Raises event when message arrives, if error: event message == 0
		private void StartListen(SslStream sslStream)
		{
			byte[] buffer = new byte[2048];
			byte[] incommingMessage;

			while (true)
			{
				incommingMessage = ReadMessage(sslStream, buffer);
				if (buffer != null)
					RaiseEvent(incommingMessage);
			}
		}

		//Read message from SSL stream.
		//IN: SSL stream, buffer.
		//OUT: fills buffer; Incomming message (byte[])
		private void ReadMessage(SslStream stream, byte[] buffer)
		{
			string message = null;
			try
			{
				int bytesRead = stream.Read(buffer, 0, buffer.Length);
			}
			catch (Exception e)
			{
				RaiseEvent(0);
				buffer = null;
				continue;
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

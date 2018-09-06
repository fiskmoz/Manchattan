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
		private SslStream sslStream;

		public SSLListener(SslStream stream)
		{
			sslStream = stream;

			Thread listeningThread = new Thread(StartListen);
			listeningThread.Start();
		}

		//Start to listen for incomming messages.
		private void StartListen()
		{
			byte[] buffer = new byte[2048];
			string incommingMessage;

			while (true)
			{
				incommingMessage = ReadMessage(sslStream, buffer);
				RaiseEvent(incommingMessage);

			}
		}

		//Read message from SSL stream.
		//IN: SSL stream, buffer.
		//OUT: Incomming message (string)
		private string ReadMessage(SslStream stream, byte[] buffer)
		{
			string message = null;
			try
			{
				int bytesRead = stream.Read(buffer, 0, buffer.Length);
				if (bytesRead > 0)
				{
					message = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
				}

				return message;
			}
			catch (Exception e)
			{
				return e.InnerException.Message;
			}
		}

		public delegate void EventHandler(Object sender, IncommingMessage eventArgs);
		public static event EventHandler IncommingMessage;

		public void RaiseEvent(string incomming)
		{
			IncommingMessage message = new IncommingMessage();
			message.Message = incomming;
			IncommingMessage(this, message);
		}
	}

	class IncommingMessage : EventArgs
	{
		public string Message { get; set; }
	}
}

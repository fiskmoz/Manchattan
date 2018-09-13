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
                            RaiseEvent(messageData.ToString());
                        message = null;
                        //RaiseEvent(message);
                    }
                    
                }
                /*
                do
                {

                    try
                    {
                        bytesRead = stream.Read(incommingMessage, 0, incommingMessage.Length);

                    }
                    catch (Exception e)
                    {
                        bytesRead = 0;
                        message = null;
                    }
                    message = Encoding.UTF8.GetString(incommingMessage, 0, bytesRead).Replace('\0', ' ');
                    //Decoder decoder = Encoding.UTF8.GetDecoder();
                    //char[] chars = new char[decoder.GetCharCount(incommingMessage, 0, bytesRead)];
                    messageData.Append(message);
                    Console.WriteLine(messageData.ToString());
                    if (messageData.ToString().Length != 0)
                    {
                        if (messageData.ToString()[0] == ' ')
                        {
                            messageData = new StringBuilder();
                            bytesRead = 0;
                        }
                    }

                    if (messageData.ToString().IndexOf("\r\n") > bytesRead && bytesRead != 0)
                    {
                        break;
                    }
                    
                } while (bytesRead >= 0);
                Console.WriteLine(messageData.ToString());
                */
                //RaiseEvent(messageData.ToString());
                if (stopListen) continue;
            }
		}

		//Eventhandling
		public delegate void EventHandler(Object sender, IncommingMessage eventArgs);
		public event EventHandler IncommingMessage;

		//Raises IncommingMessage event.
		//IN: Byte array containing the message.
		public void RaiseEvent(string incomming)
		{
			IncommingMessage message = new IncommingMessage();
			message.Message = incomming;
			IncommingMessage(this, message);
		}
	}

	//IncommingMessage Event argument declaration. Needed to send let EventHandler catch message.
	class IncommingMessage : EventArgs
	{
		public string Message { get; set; }
	}
}

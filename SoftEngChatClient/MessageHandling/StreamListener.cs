using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftEngChatClient.MessageHandling
{
	interface StreamListener
	{
		void StopListen();
		void StartListen();
		void Listen();
		void RaiseEvent(string incomming);
		event EventHandler IncommingMessage;
	}
}

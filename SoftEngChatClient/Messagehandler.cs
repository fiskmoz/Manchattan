using System;
using System.Text;

namespace SoftEngChatClient.Model.SSLCommunication
{
	internal class Messagehandler
	{
		private string userName;
		private SSLConnector server;

		/********************************************************************************************/
		/*		README:																				*/
		/*			1.	Maybe catch incomming message event in driver instead of message handler?	*/
		/*				Let driver use messagehandler-functions instead.							*/
		/*			2.	Maybe raise events in MessageHandler for driver to catch depending			*/
		/*				on type of incomming message?												*/
		/********************************************************************************************/

		//Handles messages arriving at Client.
		public Messagehandler(string userName, SSLConnector server)
		{
			this.userName = userName;
			this.server = server;
		}

		//Eventhandler, Consumes IncommingMessage Events.
		internal void HandleMessage(object sender, IncommingMessage message)
		{
			if(message == null) //Error when event was raised.
			{
				Console.WriteLine("ERROR: Event for incomming message was raised but no message arrived.");
				return;
			}

			string incomming = Encoding.UTF8.GetString(message.Message); //Encoding!

			// Insert code how to handle a message here!
			
		}
	}
}
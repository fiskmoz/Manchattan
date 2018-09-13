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
		internal void HandleIncommingMessage(object sender, IncommingMessage message)
		{
			string incomming = Encoding.UTF8.GetString(message.Message); //Encoding!

			if ( (int) incomming[0] == (int) MessageType.loginACK){
			}
			// Insert code how to handle a message here!
			
		}

		public delegate void EventHandler(Object sender, LoginValid eventArgs);
		public event EventHandler LoginValid;

		private void RaiseEvent(bool isValid)
		{
			LoginValid flag = new LoginValid();
			flag.isValid = isValid;
			LoginValid(this, flag);
		}

	}

	class LoginValid : EventArgs
	{
		public bool isValid;
	}
}
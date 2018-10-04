using SoftEngChatClient.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftEngChatClient.Model
{
    internal class Messagehandler
    {
        public Messagehandler()
        {
        }

		//public delegate void EventHandler(Object sender, EventArgs eventArgs);
		public event EventHandler IncommingRegAck;
		public event EventHandler IncommingLoginAck;
		public event EventHandler IncommingClientMessage;
		public event EventHandler IncommingOnlineList;

		//Handles messages arriving at Client.
		//Eventhandler, Consumes IncommingMessage Events.
		internal void HandleIncommingMessage(object sender, IncommingMessage message)
        {

            string[] incomming = ParseMessage(message.Message);
            switch (incomming[0])
            {
                case "1'":
                    HandleRegistrationACK(incomming);
                    break;
                case "2":
                    HandleClientMessage(incomming);
                    break;
                case "4":
                    HandleLoginACK(incomming);
                    break;
                case "6":
                    HandleUpdateOnlineList(incomming);
                    break;
            }
		}

		private void HandleRegistrationACK(string[] incomming)
		{
			IncommingRegAck(this, new RegAck(incomming[1] == "1"));
		}

		private void HandleClientMessage(string[] incomming)
		{
			IncommingClientMessage(this, new ClientMessage(incomming));
		}

		private void HandleLoginACK(string[] incomming)
		{
			IncommingLoginAck(this, new LoginAck(incomming[1] == "1"));
		}

		private void HandleUpdateOnlineList( string[] incomming)
		{
			List<string> onlineList = new List<string>();

			for(int i = 1; i <= incomming.Length; i++)
				onlineList.Add(incomming[i]);

			IncommingOnlineList(this, new OnlineList(onlineList));

		}
		/*
        private void HandleRegistrationACK(string inc)
        {
            if(inc[1] == '1')
            {
				driver.CloseRegWindow();
            }
            else
            {
				driver.RegistrationRejected();
            }
        }

        private void HandleClientMessage(string inc)
        {
            string[] parsed = ParseMessage(inc);
            string sender = parsed[1];
            string receiver = parsed[2];
            string message = parsed[3];

            if(parsed.Length > 4)
            {
                for(int i = 4; i < parsed.Length; i++)
                {
                    message += ":" + parsed[i];
                }
            }
                


            if (receiver == "All")
            {
                driver.ChatWindowPrint(sender,message);
            }
            else
            {   
                driver.AddNewIndividualChat(sender);
                System.Threading.Thread.Sleep(100);
                driver.IndividualChatPrint(sender, message);
            }
        }

        private void HandleLoginACK(string inc)
        {
            if(inc[1] == '1')
            {
                driver.Login(inc);
            }
            else
            {
            }
        }

        private void HandleUpdateOnlineList(string inc)
        {
            driver.UpdateOnlineList(inc);
        }
		*/
		private string[] ParseMessage(string incomming)
        {
            string[] messageArray;

            messageArray = incomming.Split(':');

            return messageArray;
        }
    }
}
using SoftEngChatClient.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftEngChatClient.Model.SSLCommunication
{
    internal class Messagehandler
    {
        ClientDriver driver;

        public Messagehandler(ClientDriver Driver)
        {
            driver = Driver;
        }

        //Handles messages arriving at Client.
        //Eventhandler, Consumes IncommingMessage Events.
        internal void HandleIncommingMessage(object sender, IncommingMessage message)
        {
            string incomming = message.Message;
            switch (incomming[0])
            {
                case '1':
                    HandleRegistrationACK(incomming);
                    break;
                case '2':
                    HandleClientMessage(incomming);
                    break;
                case '4':
                    HandleLoginACK(incomming);
                    break;
                case '6':
                    HandleUpdateOnlineList(incomming);
                    break;
            }
        }

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

        private string[] ParseMessage(string incomming)
        {
            string[] messageArray;

            messageArray = incomming.Split(':');

            return messageArray;
        }
    }
}
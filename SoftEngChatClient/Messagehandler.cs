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
                // REGISTRATION SUCCESS, DISPLAY?
            }
            else
            {
				// REGISTRATION FAILED, DISPLAY?
				driver.RegistrationRejected();
            }
        }

        private void HandleClientMessage(string inc)
        {
            string sender = "Nicklas"; // SHOULD APPLY CODE TO FILTER OUT SENDER, RECEIVER AND MESSAGE
            driver.AddNewIndividualChatWindow(sender);
        }

        private void HandleLoginACK(string inc)
        {
            if(inc[1] == '1')
            {
                // LOGIN SUCCESS, CALLING LOGIN FUNCTION
                driver.Login(inc);
            }
            else
            {
                // DISPLAY LOGIN FAILED.
            }
        }

        private void HandleUpdateOnlineList(string inc)
        {
            driver.UpdateOnlineList(inc);
        }
    }
}
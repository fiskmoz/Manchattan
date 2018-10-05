﻿using SoftEngChatClient.Model.SSLCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using SoftEngChatClient.Drivers;

namespace SoftEngChatClient
{
    class IndividualChatDriver
    {
        IndividualChatWindow window;
        private SpamProtector spam;
        SSLWriter writer;
        private string username;
        private string receiver;

        public IndividualChatDriver(SSLWriter sllWriter, string Username, string Receiver)
        {
            username = Username;
            receiver = Receiver;
            window = new IndividualChatWindow(receiver);
            spam = new SpamProtector();
            SetupListners();
            writer = sllWriter;
            new Thread(() => window.ShowDialog()).Start();
            
        }

        private void SetupListners()
        {
            window.IndivudualFormClosed += new FormClosingEventHandler(icd_WindowClosed);
            window.IndividualSendButtonClicked += new EventHandler(icd_SendButtonClicked);
            window.IndividualMessageBoxReleased += new KeyEventHandler(icd_EnterKeyReleased);
            window.IndividualChatWindowLoaded += new EventHandler(icd_WindowLoaded);
        }
        private void icd_WindowLoaded(object sender, EventArgs e)
        {

        }

        private void icd_EnterKeyReleased(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                icd_SendButtonClicked(sender, e);
            }
        }

        private void icd_SendButtonClicked(object sender, EventArgs e)
        {
            if (window.removeEnterWhenSending().Length > 0)
            {
                spam.SpamAppend();
                if (spam.IsNotSpamming())
                {
                    writer.WriteClient(MessageType.client, username, receiver, window.removeEnterWhenSending());
                    window.AppendTextBox("[ME] : " + window.removeEnterWhenSending());
                }
                else
                {
                    window.AppendTextBox("[Program] Don´t spam");
                }
            }
            window.clearMessageBox();

        }

        private void icd_WindowClosed(object obj, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                window.Hide();
            }
        }

        public string getUsername()
        {
            return username;
        }

        public string getSender()
        {
            return receiver;
        }

        public void displayWindow()
        {
            new Thread(() => window.ShowDialog()).Start();
        }

        public void ReceiveMessage(string message)
        {
            window.AppendTextBox("["+receiver+"] : "+message);
        }

        public bool isWindowVisible()
        {
            return window.Visible;
        }
    }
}

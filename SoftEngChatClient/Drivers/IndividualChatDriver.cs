using SoftEngChatClient.Model.SSLCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using SoftEngChatClient.Drivers;
using SoftEngChatClient.MessageHandling;
using System.Net.Sockets;
using SoftEngChatClient.Model;
using SoftEngChatClient.P2P;

namespace SoftEngChatClient
{
    class IndividualChatDriver
    {
        IndividualChatWindow window;
        private SpamProtector spam;
        StreamWriter writer;
        private string username;
        private string receiver;
        private FileManager fm;
		private P2PListener p2pListener;

        public IndividualChatDriver(StreamWriter sllWriter, string Username, string Receiver, FileManager fm)
        {
            username = Username;
            receiver = Receiver;
            this.fm = fm;
            window = new IndividualChatWindow(receiver);
            spam = new SpamProtector();
            SetupListners();
            writer = sllWriter;

            new Thread(() => Application.Run(window)).Start();
            Thread.Sleep(10);
            //new Thread(() => window.Show()).Start();
        }

		public IndividualChatDriver(string username, string receiver, FileManager fm, NetworkStream netstream, Messagehandler mh)
		{
			this.username = username;
			this.receiver = receiver;
			this.fm = fm;

			window = new IndividualChatWindow(receiver);
			spam = new SpamProtector();
			SetupListners();
			writer = new P2PWriter(netstream);
			p2pListener = new P2PListener(netstream);

			mh.Subscribe(p2pListener);
			p2pListener.StartListen();

			new Thread(() => Application.Run(window)).Start();
			Thread.Sleep(10);
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
            string chatLog = fm.LoadIndividualChat(username, receiver);
            window.AppendTextBox(chatLog);
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
            string chatLog = window.getChatBox();
            if (chatLog != "")
            {
                fm.SaveIndividualChat(username, receiver, chatLog);
            }
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
            if(window.InvokeRequired)
            {
                window.Invoke(new Action(displayWindow));
                return;
            }
            window.Show();
        }

        public void hideWindow()
        {
            if (window.InvokeRequired)
            {
                window.Invoke(new Action(hideWindow));
                return;
            }
            window.Hide();
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

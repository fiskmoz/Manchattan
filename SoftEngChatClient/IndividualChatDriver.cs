using SoftEngChatClient.Model.SSLCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace SoftEngChatClient
{
    class IndividualChatDriver
    {
        IndividualChatWindow window;
        SSLWriter writer;
        private string username;
        private string receiver;
        int spam;

        public IndividualChatDriver(SSLWriter sllWriter, string Username, string Receiver)
        {
            username = Username;
            receiver = Receiver;
            window = new IndividualChatWindow(receiver);
            SetupListners();
            writer = sllWriter;
            new Thread(() => window.ShowDialog()).Start();
        }

        private void SetupListners()
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(cd_TimerElapsed);
            timer.Enabled = true;

            window.IndivudualFormClosed += new EventHandler(icd_WindowClosed);
            window.IndividualSendButtonClicked += new EventHandler(icd_SendButtonClicked);
            window.IndividualMessageBoxReleased += new KeyEventHandler(icd_EnterKeyReleased);
            window.IndividualChatWindowLoaded += new EventHandler(icd_WindowLoaded);
        }
        private void cd_TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (spam >= 0)
            {
                spam--;
            }
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
            spam++;

            if ((window.getTextMessageBox().Length > 0) && spam < 5)
            {
                writer.WriteClient(MessageType.client, username, receiver, window.removeEnterWhenSending());
                window.AppendTextBox("[ME] : " + window.removeEnterWhenSending());
            }

            else
            {
                window.AppendTextBox("[Program] Don´t spam");
            }
            window.clearMessageBox();

        }

        private void icd_WindowClosed(object obj, EventArgs e)
        {

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
            window.ShowDialog();
        }

        public void ReceiveMessage(string message)
        {
            window.AppendTextBox("["+receiver+"] : "+message);
        }
    }
}

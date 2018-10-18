using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftEngChatClient
{
    public partial class IndividualChatWindow : Form
    {
        public event EventHandler IndividualChatWindowLoaded;
        public event KeyEventHandler IndividualMessageBoxReleased;
        public event EventHandler IndividualSendButtonClicked;
        public event FormClosingEventHandler IndivudualFormClosed;

        public IndividualChatWindow(string username)
        {
            InitializeComponent();
            this.UsernameLabel.Text = username;
        }

        private void IndividualSendButton_Click(object sender, EventArgs e)
        {
            IndividualSendButtonClicked(this, e);
        }

        private void IndividualChatWindow_Load(object sender, EventArgs e)
        {
           IndividualChatWindowLoaded(this, e);
        }

        private void IndividualMessageBox_KeyUp(object sender, KeyEventArgs e)
        {
            IndividualMessageBoxReleased(this, e);
        }

        private void IndividualChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            IndivudualFormClosed(this, e);
        }

        public void clearMessageBox()
        {
            IndividualMessageBox.Clear();
        }

        // Print a string to the ChatBox and add the message to the list.
        public void AppendTextBox(List<string> L, string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<List<string>, string>(AppendTextBox), new object[] { L, value });
                return;
            }
            IndividualChatBox.AppendText(value);
        }
        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            IndividualChatBox.AppendText(value + System.Environment.NewLine);
        }

        //Returnerar skrivfältet
        public string getTextMessageBox()
        {
            return IndividualMessageBox.Text;
        }

        //Returnerar läsfältet
        public string getChatBox()
        {
            return IndividualChatBox.Text;
        }
        public string getUserName()
        {
            return this.UsernameLabel.Text;

        }

        public string removeEnterWhenSending()
        {
            if (IndividualMessageBox.Text.Contains(System.Environment.NewLine))
            {
                return IndividualMessageBox.Text.Remove(IndividualMessageBox.Text.IndexOf(System.Environment.NewLine));
            }
            return IndividualMessageBox.Text;
        }

        private void poweredBy_Click(object sender, EventArgs e)
        {

        }

        private void IndividualSendButton_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void IndividualSendButton_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void emojiLogoBox_MouseHover(object sender, EventArgs e)
        {
            emojiPanel.Size = new Size(150, 30);
            emojiPanel.BackColor = Color.SteelBlue;
            emojiPanel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void emojiLogoBox_MouseLeave(object sender, EventArgs e)
        {
            emojiPanel.Size = new Size(30, 30);
            emojiPanel.BackColor = Color.Transparent;
            emojiPanel.BorderStyle = BorderStyle.None;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manchaticons;

namespace SoftEngChatClient
{
    public partial class IndividualChatWindow : Form
    {
        public event EventHandler IndividualChatWindowLoaded;
        public event KeyEventHandler IndividualMessageBoxReleased;
        public event EventHandler IndividualSendButtonClicked;
        public event FormClosingEventHandler IndivudualFormClosed;
        public event EventHandler SendFileEvent;


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

        public void ClearMessageBox()
        {
            IndividualMessageBox.Clear();
        }

        public void ClearChatBox()
        {
            IndividualChatBox.Clear();
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
            if(allEmoticonsPanel.Visible == false){
                emojiPanel.Size = new Size(30, 30);
                emojiPanel.BackColor = Color.Transparent;
                emojiPanel.BorderStyle = BorderStyle.None;
            }
        }

        private void emojiLogoBox_Click(object sender, EventArgs e)
        {
            if (allEmoticonsPanel.Visible == false)
            {
                emojiPanel.Size = new Size(150, 30);
                emojiPanel.BackColor = Color.SteelBlue;
                allEmoticonsPanel.Visible = true;
            }
            else if (allEmoticonsPanel.Visible == true)
            {
                allEmoticonsPanel.Visible = false;
            }
        }

        private void msgTextBoxPanel_Click(object sender, EventArgs e)
        {
            if (allEmoticonsPanel.Visible == true)
            {
                emojiPanel.Size = new Size(30, 30);
                emojiPanel.BackColor = Color.Transparent;
                emojiPanel.BorderStyle = BorderStyle.None;
                allEmoticonsPanel.Visible = false;
            }
        }

        private void IndividualChatBox_Click(object sender, EventArgs e)
        {
            if (allEmoticonsPanel.Visible == true)
            {
                emojiPanel.Size = new Size(30, 30);
                emojiPanel.BackColor = Color.Transparent;
                emojiPanel.BorderStyle = BorderStyle.None;
                allEmoticonsPanel.Visible = false;
            }
        }

        private void IndividualMessageBox_Click(object sender, EventArgs e)
        {
            if (allEmoticonsPanel.Visible == true)
            {
                emojiPanel.Size = new Size(30, 30);
                emojiPanel.BackColor = Color.Transparent;
                emojiPanel.BorderStyle = BorderStyle.None;
                allEmoticonsPanel.Visible = false;
            }
        }

        private void emojiHappy_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Happy;
        }

        private void emojiSad_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Sad;
        }

        private void emojiTongue_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Tongue;
        }

        private void emojiDevil_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Devil;
        }

        private void emojiThinking_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Thinking;
        }

        private void emojiSick_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Sick;
        }

        private void emojiMuted_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Muted;
        }

        private void emojiSleeping_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Sleeping;
        }

        private void emojiShocked_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Shocked;
        }

        private void emojiShockedLightly_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Shocked_lightly;
        }

        private void emojiCrying_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Crying;
        }

        private void emojiAngry_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Angry;
        }

        private void emojiKiss_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Kiss;
        }

        private void emojiSmart_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Smart;
        }

        private void emojiCool_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Cool;
        }

        private void emojiInLove_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.In_love;
        }

        private void emojiWink_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Wink;
        }

        private void emojiHappier_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Happier;
        }

        private void emojiDyingLaughter_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Dying_laugher;
        }

        private void emojiPoo_Click(object sender, EventArgs e)
        {
            IndividualMessageBox.Text = IndividualMessageBox.Text + Emoji.Poo;
        }

        private void msgTextBoxPanel_Paint(object sender, PaintEventArgs e)
        {
            IndividualMessageBox.Select();
            IndividualMessageBox.SelectionStart = IndividualMessageBox.Text.Length + 1;
        }

        private void IndividualMessageBox_TextChanged(object sender, EventArgs e)
        {
            IndividualMessageBox.SelectionStart = IndividualMessageBox.Text.Length + 1;
        }

        public Label getStatusTextLabel()
        {
            return statusTextLbl;
        }

        private void SendFileBtn_Click(object sender, EventArgs e)
        {
            SendFileEvent(sender, e);
        }
    }
}

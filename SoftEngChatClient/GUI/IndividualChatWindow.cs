﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftEngChatClient.GUI
{
    public partial class IndividualChatWindow : Form
    {
        public event EventHandler IndividuaChatWindowClosed;
        public event EventHandler IndividualChatWindowLoaded;
        public event KeyEventHandler IndividualMessageBoxReleased;
        public event EventHandler IndividualSendButtonClicked;

        public IndividualChatWindow()
        {
            InitializeComponent();
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
            IndividualChatBox.AppendText(value + System.Environment.NewLine);
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
    }
}

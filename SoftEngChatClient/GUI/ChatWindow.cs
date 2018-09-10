﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftEngChatClient
{
    public partial class ChatWindow : Form
    {
        public event EventHandler sendButtonClicked;
        public event EventHandler chatWindowClosed;
        public event KeyPressEventHandler messageBoxKeyPressed;
        public event EventHandler previousMessageButtonClick;
        public event EventHandler ChatWindowLoad;

        public ChatWindow()
        {
            InitializeComponent();
        }

        // When send button is clicked.
        private void SendButton_Click(object sender, EventArgs e)
        {
            sendButtonClicked(this, e);
        }

        // When ChatWindow is closed, 
        // Messages are saved in file then program closes.
        private void ChatWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            chatWindowClosed(this, e);
        }

        // When pressing enter while inside the MessageBox, send the message.
        private void MessageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            messageBoxKeyPressed(this, e);   
        }

        // Experimental, isnt working as intented yet.
        private void PreviousMessagesButton_Click(object sender, EventArgs e)
        {
            previousMessageButtonClick(this, e);
        }

        private void ChatWindow_Load(object sender, EventArgs e)
        {
            ChatWindowLoad(this, e);
        }

        public void clearMessageBox()
        {
            MessageBox.Clear();
        }

        // Print a string to the ChatBox and add the message to the list.
        public void AppendTextBox(List<string> L, string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<List<string>, string>(AppendTextBox), new object[] { L, value });
                return;
            }
            ChatBox.Text += value;
            L.Add(value);
        }

        public string getTextMessageBox()
        {
            return MessageBox.Text;
        }

    }
}
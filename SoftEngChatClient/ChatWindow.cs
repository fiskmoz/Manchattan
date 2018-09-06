using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public TcpClient Client;


        public ChatWindow()
        {
            InitializeComponent();
            Thread thread = new Thread(handle_message);
            InitializeTCPConnection();
            thread.Start();
        }

        public void InitializeTCPConnection()
        {
            Client = new TcpClient();

            try
            {
                Client.Connect("127.0.0.1", 5300);
            }
            catch (Exception e)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            var stream = Client.GetStream();
            stream.Write(Encoding.ASCII.GetBytes(MessageBox.Text), 0, MessageBox.Text.Length);
            MessageBox.Clear();
        }

        private void ChatWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void ChatWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void handle_message()
        {
            var stream = Client.GetStream();
            byte[] buffer = new byte[Client.ReceiveBufferSize];
            while (Client.Connected)
            {
                int bytesRead = stream.Read(buffer, 0, Client.ReceiveBufferSize);
                if (bytesRead > 0)
                {
                    string msg = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    AppendTextBox(msg);
                }
            }
        }

        public void AppendTextBox(string value)
        {
            if(InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            ChatBox.Text += value;
        }
    }
}

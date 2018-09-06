using System;
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
        // Creating a public TCP client and a list for all previous messages to be displayed.
        public TcpClient mainClient;
        public List<string> messageList;
        public object messageListLock;

        // Creating the window,initalizing variables, creating threads to receive messages from server.
        // Reading messages from previous conversation. 
        public ChatWindow()
        {
            InitializeComponent();
            Thread thread = new Thread(handle_message);
            messageList = new List<string>();
            messageListLock = new object();
            try
            {
                messageList = File.ReadAllLines("MessageLog.txt").ToList();
            }
            catch(Exception e)
            {
                AppendTextBox("Failed to read previous messages" + System.Environment.NewLine);
            }
            InitializeTCPConnection();
            thread.Start();
        }

        // Initializes the TCP connection towards the server.
        public void InitializeTCPConnection()
        {
            mainClient = new TcpClient();
            try
            {
                mainClient.Connect("127.0.0.1", 5300);
            }
            catch (Exception e)
            {
                Application.Exit();
            }
        }

        // When send button is clicked.
        private void SendButton_Click(object sender, EventArgs e)
        {
            SendMessageToStream();
        }

        // Takes the message from the messageBox, encodes it and sends it to the stream.
        private void SendMessageToStream()
        {
            var stream = mainClient.GetStream();
            stream.Write(Encoding.ASCII.GetBytes(MessageBox.Text), 0, MessageBox.Text.Length);
            MessageBox.Clear();
        }

        // When ChatWindow is closed, 
        // Messages are saved in file then program closes.
        private void ChatWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            TextWriter tw = new StreamWriter("MessageLog.txt");
            for (int i = 0; i < messageList.Count; i++)
            {
                tw.WriteLine(messageList[i]);
            }
            tw.Close();
            Application.Exit();
        }

        // Loop that keeps track of new messages. If new message arrives from server, print it in the ChatBox.
        private void handle_message()
        {
            var stream = mainClient.GetStream();
            byte[] buffer = new byte[mainClient.ReceiveBufferSize];
            while (mainClient.Connected)
            {
                int bytesRead = stream.Read(buffer, 0, mainClient.ReceiveBufferSize);
                if (bytesRead > 0)
                {
                    string msg = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    
                    AppendTextBox(msg + System.Environment.NewLine);
                    
                }
            }
        }

        // Print a string to the ChatBox and add the message to the list.
        public void AppendTextBox(string value)
        {
            if(InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            ChatBox.Text += value;
            lock(messageListLock)
            {
                messageList.Add(value);
            }
            
        }

        // When pressing enter while inside the MessageBox, send the message.
        private void MessageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendMessageToStream();
            }
        }

        // Experimental, isnt working as intented yet.
        private void PreviousMessagesButton_Click(object sender, EventArgs e)
        {
            lock(messageListLock)
            {
                foreach (string s in messageList)
                {
                    AppendTextBox(s + System.Environment.NewLine);
                }
            }
        }
    }
}

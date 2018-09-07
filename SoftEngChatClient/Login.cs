using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftEngChat;

namespace SoftEngChatClient
{
    public partial class Login : Form
    {
        TCPNetwork network;

        // Initializes parameters and settings for the Login window.
        public Login()
        {
            InitializeComponent();
            network = new TCPNetwork();
            Thread thread = new Thread(handle_login);
            thread.Start();
        }

        public void handle_login()
        {
            var stream = network.mainClient.GetStream();
            byte[] buffer = new byte[network.mainClient.ReceiveBufferSize];
            while (network.mainClient.Connected)
            {
                int bytesRead = stream.Read(buffer, 0, network.mainClient.ReceiveBufferSize);
                if (bytesRead > 0)
                {
                    string msg = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    if (msg == "true")
                    {
                        StartChatWindow();
                    }
                }
            }
        }

        public void StartChatWindow()
        {
            ChatWindow chatWindow = new ChatWindow();
            this.Invoke((MethodInvoker)delegate ()
            {
                this.Hide();
                chatWindow.Show();
            });
            
        }

        // Creates the ChatWindow when Login button is accepted. 
        // NOTE: Should be a login check so user is accually allowed to login.
        private void LoginButton_Click(object sender, EventArgs e)
        {
            network.SendMessageToServer("1234|" + EnterEmail.Text + "|" + EnterPassword.Text, 5+EnterEmail.Text.Length+EnterPassword.Text.Length);
        }

        // Opens the register window making a registreation avalible
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.ShowDialog();
        }

        // Exits the program.
        private void ExitLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

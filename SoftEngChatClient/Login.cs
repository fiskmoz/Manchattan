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
    public partial class Login : Form
    {
        // Initializes parameters and settings for the Login window.
        public Login()
        {
            InitializeComponent();
        }

        // Creates the ChatWindow when Login button is accepted. 
        // NOTE: Should be a login check so user is accually allowed to login.
        private void LoginButton_Click(object sender, EventArgs e)
        {
            ChatWindow chatWindow = new ChatWindow();
            this.Hide();
            chatWindow.Show();
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

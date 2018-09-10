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
        public event EventHandler LoginButtonClick;
        public event EventHandler RegisterButtonClick;
        public event EventHandler ExitButtonClicked;

        // Initializes parameters and settings for the Login window.
        public Login()
        {
            InitializeComponent();
        }
            
        // Creates the ChatWindow when Login button is accepted. 
        // NOTE: Should be a login check so user is accually allowed to login.
        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginButtonClick(this, e);
        }
            
        // Opens the register window making a registreation avalible
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterButtonClick(this, e);
        }
            
        // Exits the program.
        private void ExitLogin_Click(object sender, EventArgs e)
        {
            ExitButtonClicked(this, e);
        }
    }
} 

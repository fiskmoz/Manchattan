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
        public event EventHandler CheckButtonChanged;
        public event EventHandler LoginLoaded;

        public string getUsername()
        {
            return EnterEmail.Text;
        }
        public string getPassword()
        {
            return EnterPassword.Text;
        }

        // Initializes parameters and settings for the Login window.
        public Login()
        {
            InitializeComponent();
        }
            
        // Creates the ChatWindow when Login button is accepted. 
        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginButtonClick(this, e);
        }

        // Creates the ChatWindow when Login button is accepted. 
        private void Login_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButtonClick(this, e);
            }
        }

        // Opens the register window making a registreation avalible
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterButtonClick(this, e);
        }

		internal void RegistrationOKinfo()
		{
			label1.Visible = true;
		}

		// Exits the program.
		private void ExitLogin_Click(object sender, EventArgs e)
        {
            ExitButtonClicked(this, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckButtonChanged(sender, e);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            LoginLoaded(sender, e);
        }
    }
} 

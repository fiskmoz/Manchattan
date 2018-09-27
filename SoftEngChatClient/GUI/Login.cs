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

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            System.Environment.Exit(1);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckButtonChanged(sender, e);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            LoginLoaded(sender, e);
        }

        private void EnterEmail_TextChanged(object sender, EventArgs e)
        {
            LoginButtonEnabled();
        }

        private void EnterEmail_Enter(object sender, EventArgs e)
        {
            LoginButtonEnabled();
            if (EnterEmail.Text == "Username" || EnterEmail.ForeColor == Color.Gray)
            {
                EnterEmail.Text = "";
                EnterEmail.ForeColor = Color.White;

                EnterPassword.Text = "Password";
                EnterPassword.PasswordChar = '\0';

                rememberMeCheckBox.Checked = false;

            }
        }

        private void EnterEmail_Leave(object sender, EventArgs e)
        {
            LoginButtonEnabled();
            if (EnterEmail.Text == "")
            {
                EnterEmail.Text = "Username";
                EnterEmail.ForeColor = Color.Gray;
            }
        }

        private void EnterPassword_Enter(object sender, EventArgs e)
        {
            LoginButtonEnabled();
            if (EnterPassword.Text == "Password" || EnterPassword.ForeColor == Color.Gray)
            {
                EnterPassword.Text = "";
                EnterPassword.PasswordChar = '*';
                EnterPassword.ForeColor = Color.White;

            }
            
        }

        private void EnterPassword_Leave(object sender, EventArgs e)
        {
            LoginButtonEnabled();
            if (EnterPassword.Text == "")
            {
                EnterPassword.Text = "Password";
                EnterPassword.PasswordChar = '\0';
                EnterPassword.ForeColor = Color.Gray;

            }
        }
        private void LoginButtonEnabled()
        {
            if ((String.IsNullOrWhiteSpace(EnterEmail.Text) || EnterEmail.Text == "Username") || (String.IsNullOrWhiteSpace(EnterPassword.Text) || EnterPassword.Text == "Password"))
            {
                LoginButton.Enabled = false;
                LoginButton.BackColor = Color.FromArgb(59, 177, 226);
                return;
            }

            LoginButton.Enabled = true;
            LoginButton.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void EnterPassword_TextChanged(object sender, EventArgs e)
        {
            LoginButtonEnabled();
        }
        public void resetLoginFields()
        {
            EnterEmail.Text = "Username";
            EnterPassword.Text = "Password";
            EnterPassword.PasswordChar = '*';
            EnterEmail.ForeColor = Color.Gray;
            EnterPassword.ForeColor = Color.Gray;
            rememberMeCheckBox.Checked = false;
        }
        
    }
} 

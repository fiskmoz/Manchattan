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
    public partial class Register : Form
    {
        public event EventHandler RegisterButtonClick;
        public event EventHandler CancelButtonClicked;

        // Initializes parameters and settings for the Register window.
        public Register()
        {
            InitializeComponent();
        }

        // What should happen if clicking Register in register window.
        private void RegisterAccept_Click(object sender, EventArgs e)
        {
            RegisterButtonClick(this, e);
            EnterUsername.Text = "Username";
            EnterPassword.Text = "Password";
            EnterEmail.Text = "Email";
            EnterForename.Text = "Forename";
            EnterSurname.Text = "Surname";
        }
        
        // Cancels the registration and returns to Login window.
        private void RegisterCancel_Click(object sender, EventArgs e)
        {
            CancelButtonClicked(this, e);
        }

        private void EmailLabel_Click(object sender, EventArgs e)
        {

        }

        public string getUserName()
        {
            return this.EnterUsername.Text;
        }
        public string getPassword()
        {
            return this.EnterPassword.Text;
        }
        public string getEmail()
        {
            return this.EnterEmail.Text;
        }
        public string getForename()
        {
            return this.EnterForename.Text;
        }
        public string getSurname()
        {
            return this.EnterSurname.Text;
        }

		internal void RegistrationRejected()
		{
			regRejectLbl.Visible = true;
		}

        private void EnterUsername_Enter(object sender, EventArgs e)
        {
            if(EnterUsername.Text == "Username")
            {
                EnterUsername.Text = "";
                EnterUsername.ForeColor = Color.White;
            }
        }

        private void EnterUsername_Leave(object sender, EventArgs e)
        {
            if(EnterUsername.Text == "")
            {
                EnterUsername.Text = "Username";
                EnterUsername.ForeColor = Color.Gray;
            }
        }

        private void EnterPassword_Enter(object sender, EventArgs e)
        {
            if(EnterPassword.Text == "Password")
            {
                EnterPassword.Text = "";
                EnterPassword.ForeColor = Color.White;
            }
        }

        private void EnterPassword_Leave(object sender, EventArgs e)
        {
            if (EnterPassword.Text == "")
            {
                EnterPassword.Text = "Password";
                EnterPassword.ForeColor = Color.Gray;
            }
        }

        private void EnterEmail_Enter(object sender, EventArgs e)
        {
            if (EnterEmail.Text == "Email")
            {
                EnterEmail.Text = "";
                EnterEmail.ForeColor = Color.White;
            }
        }

        private void EnterEmail_Leave(object sender, EventArgs e)
        {
            if (EnterEmail.Text == "")
            {
                EnterEmail.Text = "Email";
                EnterEmail.ForeColor = Color.Gray;
            }
        }

        private void EnterForename_Enter(object sender, EventArgs e)
        {
            if(EnterForename.Text == "Forename")
            {
                EnterForename.Text = "";
                EnterForename.ForeColor = Color.White;
            }
        }

        private void EnterForename_Leave(object sender, EventArgs e)
        {
            if (EnterForename.Text == "")
            {
                EnterForename.Text = "Forename";
                EnterForename.ForeColor = Color.Gray;
            }
        }

        private void EnterSurname_Enter(object sender, EventArgs e)
        {
            if(EnterSurname.Text == "Surname")
            {
                EnterSurname.Text = "";
                EnterSurname.ForeColor = Color.White;
            }
        }

        private void EnterSurname_Leave(object sender, EventArgs e)
        {
            if (EnterSurname.Text == "")
            {
                EnterSurname.Text = "Surname";
                EnterSurname.ForeColor = Color.Gray;
            }
        }
    }
}

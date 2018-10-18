using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftEngChatClient.Controller;

namespace SoftEngChatClient
{
    public partial class Register : Form
    {
        public event EventHandler RegisterButtonClick;
        public event EventHandler CancelButtonClicked;

        public event EventHandler EnterUsernameClicked;
        public event EventHandler EnterUsernameLeaved;

        public event EventHandler EnterPasswordClicked;
        public event EventHandler EnterPasswordLeaved;

        public event EventHandler EnterEmailClicked;
        public event EventHandler EnterEmailLeaved;

        public event EventHandler EnterForenameClicked;
        public event EventHandler EnterForenameLeaved;

        public event EventHandler EnterSurnameClicked;
        public event EventHandler EnterSurnameLeaved;

        public event EventHandler TextChangedEvent;
        public event EventHandler PwTextChangedEvent;
        

        // Initializes parameters and settings for the Register window.
        public Register()
        {
            InitializeComponent();
        }
        
       
        // What should happen if clicking Register in register window.
        private void RegisterAccept_Click(object sender, EventArgs e)
        {
            RegisterButtonClick(this, e);
        }
        
        // Cancels the registration and returns to Login window.
        private void RegisterCancel_Click(object sender, EventArgs e)
        {
            CancelButtonClicked(this, e);
        }
        
        private void EmailLabel_Click(object sender, EventArgs e)
        {

        }
        // Username
        public string getUsernameText()
        {
            return this.EnterUsername.Text;
        }
        public void setUsernameText(string newText)
        {
            this.EnterUsername.Text = newText;
        }
        public void setUsernameColor(Color newColor)
        {
            this.EnterUsername.ForeColor = newColor;
        }
        // Password
        public string getPasswordText()
        {
            return this.EnterPassword.Text;
        }
        public void setPasswordText(string newText)
        {
            this.EnterPassword.Text = newText;
        }
        public void setPasswordColor(Color newColor)
        {
            this.EnterPassword.ForeColor = newColor;
        }
        // Email
        public string getEmailText()
        {
            return this.EnterEmail.Text;
        }
        public void setEmailText(string newText)
        {
            this.EnterEmail.Text = newText;
        }
        public void setEmailColor(Color newColor)
        {
            this.EnterEmail.ForeColor = newColor;
        }
        // Forename
        public string getForenameText()
        {
            return this.EnterForename.Text;
        }
        public void setForenameText(string newText)
        {
            this.EnterForename.Text = newText;
        }
        public void setForenameColor(Color newColor)
        {
            this.EnterForename.ForeColor = newColor;
        }
        // Surname
        public string getSurnameText()
        {
            return this.EnterSurname.Text;
        }
        public void setSurnameText(string newText)
        {
            this.EnterSurname.Text = newText;
        }
        public void setSurnameColor(Color newColor)
        {
            this.EnterSurname.ForeColor = newColor;
        }


        internal void RegistrationRejected()
		{
			regRejectLbl.Visible = true;
		}

        private void EnterUsername_Enter(object sender, EventArgs e)
        {
            EnterUsernameClicked(this, e);
        }
        private void EnterUsername_Leave(object sender, EventArgs e)
        {
            EnterUsernameLeaved(this, e);
        }

        private void EnterPassword_Enter(object sender, EventArgs e)
        {
            EnterPasswordClicked(this, e);
            if(EnterPassword.Text == "")
            {
                EnterPassword.Text = "";
                EnterPassword.PasswordChar = '*';
                EnterPassword.ForeColor = Color.White;

            }
        }
        private void EnterPassword_Leave(object sender, EventArgs e)
        {

            if(EnterPassword.Text == "")
            {
                EnterPassword.Text = "Password";
                EnterPassword.PasswordChar = '\0';
                EnterPassword.ForeColor = Color.Gray;
                RegistrationColorIndicatorlbl.BackColor = System.Drawing.Color.Gray;
                RegistrationIndicatorlbl.Visible = false;
            }

          /*  try
            {
                EnterPasswordLeaved(this, e);
            }
            catch(Exception)
            {
                //
            }*/
        }

        private void EnterEmail_Enter(object sender, EventArgs e)
        {
            EnterEmailClicked(this, e);
        }
        private void EnterEmail_Leave(object sender, EventArgs e)
        {
            EnterEmailLeaved(this, e);
        }

        private void EnterForename_Enter(object sender, EventArgs e)
        {
            EnterForenameClicked(this, e);
        }
        private void EnterForename_Leave(object sender, EventArgs e)
        {
            EnterForenameLeaved(this, e);
        }

        private void EnterSurname_Enter(object sender, EventArgs e)
        {
            EnterSurnameClicked(this, e);
        }
        private void EnterSurname_Leave(object sender, EventArgs e)
        {
            EnterSurnameLeaved(this, e);
        }

        public void SetRegisterAccept(bool value, Color backColor)
        {
            RegisterAccept.Enabled = value;
            RegisterAccept.BackColor = backColor;
        }

        private void EnterUsername_TextChanged(object sender, EventArgs e)
        {
            TextChangedEvent(this, e);
        }
        private void EnterPassword_TextChanged(object sender, EventArgs e)
        {
            PwTextChangedEvent(this, e);
            TextChangedEvent(this, e);
        }
        private void EnterEmail_TextChanged(object sender, EventArgs e)
        {
            TextChangedEvent(this, e);
        }
        private void EnterForename_TextChanged(object sender, EventArgs e)
        {
            TextChangedEvent(this, e);
        }
        private void EnterSurname_TextChanged(object sender, EventArgs e)
        {
            TextChangedEvent(this, e);
        }
        public void RegLabelSet(bool set)
        {
            regRejectLbl.Visible = set;
        }

        public void ChangeColorRegistrationIndicator(int counter)
        {
            if(counter >= 10)
            {
                RegistrationColorIndicatorlbl.BackColor = System.Drawing.Color.LimeGreen;
                RegistrationIndicatorlbl.Text = "Good";
            }
            else if(counter > 1 && counter < 5)
            {
                
                RegistrationColorIndicatorlbl.BackColor = System.Drawing.Color.Red;
                RegistrationIndicatorlbl.Visible = true;
                RegistrationIndicatorlbl.Text = "Weak";
            }
            else if(counter >= 5 && counter < 10)
            {
                RegistrationColorIndicatorlbl.BackColor = System.Drawing.Color.Gold;
                RegistrationIndicatorlbl.Text = "Fair";
            }
            else
            {
                RegistrationColorIndicatorlbl.BackColor = System.Drawing.Color.Gray;
                RegistrationIndicatorlbl.Visible = false;

            }
                
        }
    }
}

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
    }
}

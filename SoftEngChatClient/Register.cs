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
        // Initializes parameters and settings for the Register window.
        public Register()
        {
            InitializeComponent();
        }

        // What should happen if clicking Register in register window.
        private void RegisterAccept_Click(object sender, EventArgs e)
        {

        }
        
        // Cancels the registration and returns to Login window.
        private void RegisterCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

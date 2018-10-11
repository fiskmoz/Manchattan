using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftEngChatClient.GUI
{
    public partial class FriendRequest : Form
    {
        public event EventHandler acceptButtonClick;
        public event EventHandler rejectButtonClick;
        public FriendRequest()
        {
            InitializeComponent();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            acceptButtonClick(this, e);
        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
            rejectButtonClick(this, e);
        }
        public Label getFriendLabel()
        {
            return usernameLabel;
        }
    }
}

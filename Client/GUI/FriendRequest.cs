using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUI
{
    public partial class FriendRequest : Form
    {
        public event EventHandler acceptButtonClick;
        public event EventHandler rejectButtonClick;

        List<string> friendRequest;

        public FriendRequest()
        {
            InitializeComponent();
            friendRequest = new List<string>();
            initializeFriendRequests();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if(FriendRequestsBox.SelectedItem != null)
            {
                acceptButtonClick(this, e);
                FriendRequestsBox.Items.RemoveAt(FriendRequestsBox.Items.IndexOf(FriendRequestsBox.SelectedItem));
            }
            
        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
            if (FriendRequestsBox.SelectedItem != null)
            {
                rejectButtonClick(this, e);
                FriendRequestsBox.Items.RemoveAt(FriendRequestsBox.Items.IndexOf(FriendRequestsBox.SelectedItem));
            }
        }

        private void initializeFriendRequests()
        {
            // READ PENDING FRIEND REQUESTS FROM FILE.
            foreach(var str in friendRequest)
            {
                FriendRequestsBox.Items.Add(str);
            }
        }

        public void AppendFriendrequest(string username)
        {
            if(!FriendRequestsBox.Items.Contains(username))
            {
                friendRequest.Add(username);
                FriendRequestsBox.Items.Add(username);
            }
        }

        public string GetSelectedFriend()
        {
            return (string)FriendRequestsBox.SelectedItem;
        }
    }
}

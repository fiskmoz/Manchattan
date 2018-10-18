using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SoftEngChatClient.Model;
using SoftEngChatClient.Model.SSLCommunication;

namespace SoftEngChatClient.Controller
{
    class RegisterDriver
    {
        private Register register;
        private SSLWriter writer;
        private int passwordStrengtCounter;
        private int previousPasswordLenght;
        private Char previousChar;

        public RegisterDriver(SSLWriter inputWriter)
        {
            this.writer = inputWriter;
            RD_ConstructGUI();
            RD_Listener();
        }
        // Construct
        public void RD_ConstructGUI()
        {
            register = new Register();
        }
        // Listeners
        public void RD_Listener()
        {
            register.RegisterButtonClick += new EventHandler(RD_RegisterButtonClick);
            register.CancelButtonClicked += new EventHandler(RD_CancelButtonClick);
            // Username Field
            register.EnterUsernameClicked += new EventHandler(RD_EnterUsernameClicked);
            register.EnterUsernameLeaved += new EventHandler(RD_EnterUsernameLeaved);
            // Password Field
            register.EnterPasswordClicked += new EventHandler(RD_EnterPasswordClicked);
            register.EnterPasswordLeaved += new EventHandler(RD_EnterPasswordLeaved);
            // Email Field
            register.EnterEmailClicked += new EventHandler(RD_EnterEmailClicked);
            register.EnterEmailLeaved += new EventHandler(RD_EnterEmailLeaved);
            // Forename Field
            register.EnterForenameClicked += new EventHandler(RD_EnterForenameClicked);
            register.EnterForenameLeaved += new EventHandler(RD_EnterForenameLeaved);
            // Surname Field
            register.EnterSurnameClicked += new EventHandler(RD_EnterSurnameClicked);
            register.EnterSurnameLeaved += new EventHandler(RD_EnterSurnameLeaved);
            // TextChanged
            register.TextChangedEvent += new EventHandler(RD_TextChanged);
            register.PwTextChangedEvent += new EventHandler(RD_PwTextChanged);
        }

		public void RD_Subscribe(Messagehandler mh)
		{
			mh.IncommingRegAck += new EventHandler(RD_RegisterCheck);
		}
        // Button Clicks
        private void RD_RegisterButtonClick(object sender, EventArgs e)
        {
            writer.WriteRegister(MessageType.register, register.getUsernameText(), register.getEmailText(), register.getPasswordText(),
              register.getForenameText(), register.getSurnameText());
        }
        private void RD_CancelButtonClick(object sender, EventArgs e)
        {
            register.Close();
            register.RegLabelSet(false);
        }
        // Check Register ACK
        public void RD_RegisterCheck(object sender, EventArgs ack)
        {
            if(register.InvokeRequired)
            {
                register.Invoke(new Action<object, EventArgs>(RD_RegisterCheck), new object[] { sender, ack });
                return;
            }
            if (((RegAck)ack).message == true)
            {
                RD_ClearFields();
                register.Close();
                register.RegLabelSet(false);
            }

            else
                RD_RegistrationRejected();

        }
        // Rejected Registration
        internal void RD_RegistrationRejected()
        {
            if (register.InvokeRequired)
            {
                register.Invoke(new Action(register.RegistrationRejected));
                return;
            }
            register.RegistrationRejected();
        }
        // Username Field Action
        private void RD_EnterUsernameClicked(object sender, EventArgs e)
        {
            if (register.getUsernameText() == "Username")
            {
                register.setUsernameText("");
                register.setUsernameColor(Color.White);
            }
        }
        private void RD_EnterUsernameLeaved(object sender, EventArgs e)
        {
            if (register.getUsernameText() == "")
            {
                register.setUsernameText("Username");
                register.setUsernameColor(Color.Gray);
            }
        }
        // Password Field Action
        private void RD_EnterPasswordClicked(object sender, EventArgs e)
        {
            if (register.getPasswordText() == "Password")
            {
                register.setPasswordText("");
                register.setPasswordColor(Color.White);
            }
        }
        private void RD_EnterPasswordLeaved(object sender, EventArgs e)
        {
            if (register.getPasswordText() == "")
            {
                register.setPasswordText("Password");
                register.setPasswordColor(Color.Gray);
            }
        }
        // Email Field Action
        private void RD_EnterEmailClicked(object sender, EventArgs e)
        {
            if (register.getEmailText() == "Email")
            {
                register.setEmailText("");
                register.setEmailColor(Color.White);
            }
        }
        private void RD_EnterEmailLeaved(object sender, EventArgs e)
        {
            if (register.getEmailText() == "")
            {
                register.setEmailText("Email");
                register.setEmailColor(Color.Gray);
            }
        }
        // Forename Field Action
        private void RD_EnterForenameClicked(object sender, EventArgs e)
        {
            if (register.getForenameText() == "Forename")
            {
                register.setForenameText("");
                register.setForenameColor(Color.White);
            }
        }
        private void RD_EnterForenameLeaved(object sender, EventArgs e)
        {
            if (register.getForenameText() == "")
            {
                register.setForenameText("Forename");
                register.setForenameColor(Color.Gray);
            }
        }
        // Surname Field Action
        private void RD_EnterSurnameClicked(object sender, EventArgs e)
        {
            if (register.getSurnameText() == "Surname")
            {
                register.setSurnameText("");
                register.setSurnameColor(Color.White);
            }
        }
        private void RD_EnterSurnameLeaved(object sender, EventArgs e)
        {
            if (register.getSurnameText() == "")
            {
                register.setSurnameText("Surname");
                register.setSurnameColor(Color.Gray);
            }
        }
        // Text Changed Action
        private void RD_TextChanged(object sender, EventArgs e)
        {
            RD_RegisterButtonEnabled();
        }
        // Reset
        public void RD_ClearFields()
        {
            register.setUsernameText("Username");
            register.setUsernameColor(Color.Gray);

            register.setPasswordText("Password");
            register.setPasswordColor(Color.Gray);

            register.setEmailText("Email");
            register.setEmailColor(Color.Gray);

            register.setForenameText("Forename");
            register.setForenameColor(Color.Gray);

            register.setSurnameText("Surname");
            register.setSurnameColor(Color.Gray);
        }
        
        public void RD_OpenRegisterWindow(object sender, EventArgs e)
        {
            register.ShowDialog();
        }

        private void RD_RegisterButtonEnabled()
        {
            if ((String.IsNullOrWhiteSpace(register.getUsernameText()) || register.getUsernameText() == "Username") ||
                (String.IsNullOrWhiteSpace(register.getPasswordText()) || register.getPasswordText() == "Password") ||
                (String.IsNullOrWhiteSpace(register.getEmailText()) || register.getEmailText() == "Email") ||
                (String.IsNullOrWhiteSpace(register.getForenameText()) || register.getForenameText() == "Forename") ||
                (String.IsNullOrWhiteSpace(register.getSurnameText()) || register.getSurnameText() == "Surname"))

            {
                register.SetRegisterAccept(false, Color.FromArgb(41, 164, 221));
                return;
            }
            register.SetRegisterAccept(true, Color.FromArgb(64, 64, 64));

        }

        private void RD_PwTextChanged(object sender, EventArgs e)
        {
            int length = register.getPasswordText().Count();
            char currentChar = register.getPasswordText()[length];
            if (length > previousPasswordLenght)
            {
                if (length > 3)
                {
                    passwordStrengtCounter++;
                }
                if (Char.IsUpper(currentChar))
                {
                    passwordStrengtCounter++;
                }
                if (Char.IsNumber(currentChar))
                {
                    passwordStrengtCounter++;
                }
            }
            else
            {
                passwordStrengtCounter--;
                if (Char.IsUpper(previousChar))
                {
                    passwordStrengtCounter--;
                }
                if (Char.IsNumber(previousChar))
                {
                    passwordStrengtCounter--;
                }
            }
            previousChar = currentChar;
            previousPasswordLenght = length;
        }
    }
}

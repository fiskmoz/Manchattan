using SoftEngChatClient.Controller;
using SoftEngChatClient.Model.SSLCommunication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftEngChatClient.Drivers
{
    class LoginWindowDriver
    {
        SSLWriter writer;
        Login loginWindow;
        private RegisterDriver regDriver;

        private string rememberMePassword;
        private bool rememberMe;

        public LoginWindowDriver(SSLWriter writer)
        {
            loginWindow = new Login();
            regDriver = new RegisterDriver(writer);
            this.writer = writer;
        }
        private void SetupListeners()
        {
            loginWindow.RegisterButtonClick += new EventHandler(regDriver.RD_OpenRegisterWindow);
            loginWindow.LoginButtonClick += new EventHandler(LoginButtonClicked);
            loginWindow.ExitButtonClicked += new EventHandler(LoginExitWindow);
            loginWindow.CheckButtonChanged += new EventHandler(CheckBoxChanged);
            loginWindow.LoginLoaded += new EventHandler(LoginIsLoaded);
            loginWindow.loginClosed += new FormClosedEventHandler(LoginExitWindow);
        }

        private void LoginIsLoaded(object sender, EventArgs e)
        {
            CheckSessionFileExist();
            FileManager fileManager = new FileManager();

            string loginCredentials;
            loginCredentials = fileManager.ReadFromFile("SessionSave.txt");

            string username;
            string password;

            if (loginCredentials == ":")
            {
                loginWindow.rememberMeCheckBox.Checked = false;
                return;
            }
            string[] userInfo;
            userInfo = loginCredentials.Split(':');

            username = userInfo[0];
            password = userInfo[1];

            loginWindow.EnterEmail.Text = username;
            loginWindow.EnterPassword.Text = password;
            loginWindow.EnterPassword.PasswordChar = '*';
            loginWindow.rememberMeCheckBox.Checked = true;
        }

        public void CheckSessionFileExist()
        {
            FileManager fileManager = new FileManager();
            string sessionPathCreate = AppDomain.CurrentDomain.BaseDirectory + @"\" + "SessionSave.txt";
            string[] emptyString = { "" };
            Console.WriteLine("CheckSessionFileExist");
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\" + "SessionSave.txt"))
            {
                Console.WriteLine("No File present, trying to add");
                fileManager.WriteToFile(sessionPathCreate, emptyString);
            }
        }

        private void CheckBoxChanged(object sender, EventArgs e)
        {
            if (loginWindow.rememberMeCheckBox.Checked == true)
            {
                rememberMe = true;
            }
            else
            {
                rememberMe = false;
            }
        }

        private void LoginExitWindow(object sender, EventArgs e)
        {
            writer.WriteLogout(MessageType.logout);
            Thread.Sleep(1000);
            Application.Exit();
            System.Environment.Exit(1);
        }

        private void cd_OpenRegisterWindow(object sender, EventArgs e)
        {
            //regDriver.DisplayRegWindow();
        }
        private void LoginButtonClicked(object sender, EventArgs e)
        {
            writer.WriteLogin(MessageType.login, loginWindow.getUsername(), loginWindow.getPassword());
            SetUserName(loginWindow.getUsername());
            if (rememberMe == true)
            {
                SetPassword(loginWindow.getPassword());
            }
        }

        public void Login(string inc)
        {
            if (loginWindow.InvokeRequired)
            {
                loginWindow.Invoke(new Action<string>(Login), new object[] { inc });
                return;
            }
            username = loginWindow.getUsername();
            Session session = new Session(username, rememberMePassword, rememberMe);
            loginWindow.Hide();
        }

        public void HideLoginWindow()
        {
            loginWindow.Hide();
        }

        public void ShowLoginWindow()
        {
            loginWindow.Show();
        }

        /*private void cd_ClientRegisterButtonClick(object sender, EventArgs e)
        {
            writer.WriteRegister(MessageType.register, regDriver.getUserName(), regDriver.getEmail(), regDriver.getPassword(),
              regDriver.getForename(), regDriver.getSurname());
        }*/
    }
}

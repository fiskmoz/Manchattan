using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftEngChatClient.Model.SSLCommunication;
using System.Timers;
using SoftEngChatClient.Drivers;
using SoftEngChatClient.Model;

namespace SoftEngChatClient.Controller
{
	class ClientDriver
	{
        private ChatWindowDriver chatWindowDriver;
        private RegisterDriver regDriver;
		private Login loginWindow;
        private Register registerWindow;
		private SSLConnector connector;
		private SSLListener streamListener;
		private SSLWriter writer;
		private Messagehandler messagehandler;
        private LogCrypto logCrypto;

        private string username;

        private string rememberMePassword;
        private bool rememberMe;



		private const string IP = "127.0.0.1";	//ServerIP
		private const int PORT = 5300;      //Serverport

        // Creates winform thread (STAThread).
        [STAThread] // <- Makes win-forms to run in own thread!
        public void Run() //Run the program
        {
            
			streamListener.StartListen();
			Application.Run(loginWindow);
		}

		internal void CloseRegWindow()
		{
            registerWindow.RegLabelSet(false);
            if (loginWindow.InvokeRequired)
			{
				loginWindow.Invoke(new Action(loginWindow.RegistrationOKinfo));
			}

			if (registerWindow.InvokeRequired)
			{
				registerWindow.Invoke(new Action(registerWindow.Close));
                return;
			}
			loginWindow.RegistrationOKinfo();
            
			registerWindow.Close();
		}

		// When creating the ClientDriver in main (program.cs)
		public ClientDriver()
		{
            
			ConstructGUI();
            ConstructBackend();
			SetupListeners();
            chatWindowDriver = new ChatWindowDriver(writer, logCrypto);

        }

		internal void RegistrationRejected()
		{
			if (registerWindow.InvokeRequired)
			{
				registerWindow.Invoke(new Action(registerWindow.RegistrationRejected));
				return;
			}
			registerWindow.RegistrationRejected();
		}

		//Constructs GUI windows and list of individual chat windows.
		private void ConstructGUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginWindow = new Login();
            registerWindow = new Register();
            
        }

        //Constructs backend modules
        private void ConstructBackend()
        {
            regDriver = new RegisterDriver(writer);
            connector = new SSLConnector(IP, PORT); //Connect to server!
			connector.Connect();
            writer = new SSLWriter(connector.SslStream);
            streamListener = new SSLListener(connector.SslStream);
            messagehandler = new Messagehandler(this); //Needs to be changed, see Readme in MessegeHandler class
            logCrypto = new LogCrypto();

            //Random input for encryption 
            string input = "hejhejjkjdueoplikmnakduehgjdmnju";
            byte[] array = Encoding.ASCII.GetBytes(input);
            logCrypto.SetNewKey(array);
        }

        //Sets up listeners for the different events.
        private void SetupListeners()
		{
			streamListener.IncommingMessage += messagehandler.HandleIncommingMessage; //Tell messagehandler to listen for IncommingMessage Events raised by streamlistener
            chatWindowDriver.restart += new EventHandler(ChatWindowLogout);


            
            loginWindow.RegisterButtonClick += new EventHandler(cd_OpenRegisterWindow);
			loginWindow.LoginButtonClick += new EventHandler(cd_TryLogin);
			loginWindow.ExitButtonClicked += new EventHandler(cd_LoginExitWindow);
            loginWindow.CheckButtonChanged += new EventHandler(cd_CheckBoxChanged);
            loginWindow.LoginLoaded += new EventHandler(cd_LoginIsLoaded);
            loginWindow.loginClosed += new FormClosedEventHandler(cd_LoginExitWindow);
			registerWindow.RegisterButtonClick += new EventHandler(cd_ClientRegisterButtonClick);
			registerWindow.CancelButtonClicked += new EventHandler(cd_RegisterWindowCancel);
        }

        private void ChatWindowLogout(object o, EventArgs e)
        {
            connector.Connect();
            writer.stream = connector.SslStream;
            streamListener.stream = connector.SslStream;
            loginWindow.Show();
        }




        private void cd_LoginIsLoaded(object sender, EventArgs e)
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

        private void cd_CheckBoxChanged(object sender, EventArgs e)
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


        Session session = new Session(username, rememberMePassword, rememberMe);


        private void cd_OpenRegisterWindow(object sender, EventArgs e)
        {
            registerWindow.ShowDialog();
        }
        private void cd_TryLogin(object sender, EventArgs e)
        {
            writer.WriteLogin(MessageType.login, loginWindow.getUsername(), loginWindow.getPassword());
			SetUserName(loginWindow.getUsername());
            if (rememberMe == true)
            {
                SetPassword(loginWindow.getPassword());
            }
        }

        private void SetPassword(string password)
        {
            rememberMePassword = password;
        }

        private void cd_LoginExitWindow(object sender, EventArgs e)
        {
            writer.WriteLogout(MessageType.logout);
            Thread.Sleep(1000);
            Application.Exit();
            System.Environment.Exit(1);
        }
        private void cd_ClientRegisterButtonClick(object sender, EventArgs e)
        {
            writer.WriteRegister(MessageType.register, registerWindow.getUserName(), registerWindow.getEmail(), registerWindow.getPassword(),
              registerWindow.getForename(), registerWindow.getSurname());
        }
        private void cd_RegisterWindowCancel(object sender, EventArgs e)
        {
            registerWindow.Close();
        }




        public void Login(string inc)
        {
            if (loginWindow.InvokeRequired)
            {
                loginWindow.Invoke(new Action<string>(Login), new object[] { inc });
                return;
            }
            username = loginWindow.getUsername();
            loginWindow.Hide();
            chatWindow.Show();
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
    }
}

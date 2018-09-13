using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftEngChatClient.Model.SSLCommunication;

namespace SoftEngChatClient.Controller
{
	class ClientDriver
	{
		//Proper program controller/driver. GUI should generate events wich should be caught here.
		//Create new event classes GUI.		e.g.	Consume button-click event => handle by gathering
		//											the needed information and raise new event for
		//											driver or messagehandler to consume.

		private ChatWindow chatWindow;
		private Login loginWindow;
        private Register registerWindow;

		private SSLConnector connector;
		private SSLListener streamListener;
		private SSLWriter writer;
		private Messagehandler messagehandler;

        public List<string> messageList;

		private const string IP = "127.0.0.1";	//ServerIP
		private const int PORT = 5300;		//Serverport

		public ClientDriver()
		{
			ConstructGUI();
            ConstructBackend();
			SetupListeners();
		}

		//Sets up listeners for the different events.
		//Not in loop or own thread or anything. Not polling but "interupts"
		private void SetupListeners()
		{
			streamListener.IncommingMessage += messagehandler.HandleIncommingMessage; //Tell messagehandler to listen for IncommingMessage Events raised by streamlistener

			loginWindow.RegisterButtonClick += new EventHandler(cd_OpenRegisterWindow);
			loginWindow.LoginButtonClick += new EventHandler(cd_OpenLoginWindow);
			loginWindow.ExitButtonClicked += new EventHandler(cd_ExitWindow);
			registerWindow.RegisterButtonClick += new EventHandler(cd_ClientRegister);
			registerWindow.CancelButtonClicked += new EventHandler(cd_RegisterCancel);
			chatWindow.sendButtonClicked += new EventHandler(cd_ChatWindowSend);
			chatWindow.chatWindowClosed += new EventHandler(cd_ChatWindowClosed);
			chatWindow.messageBoxKeyPressed += new KeyPressEventHandler(cd_MessageBoxKeyPressed);
			chatWindow.previousMessageButtonClick += new EventHandler(cd_PreviousMessageButtonClicked);
			chatWindow.ChatWindowLoad += new EventHandler(cd_ChatWindowLoaded);
		}

		//Constructs GUI windows
		private void ConstructGUI()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			chatWindow = new ChatWindow();  //Should not handle messages (Only read user input and let backend handle the details)
											//Print output for user
			loginWindow = new Login();      //Only responsible for login-functionality (see SRP Principle)
			registerWindow = new Register();
		}

		//Constructs backend modules
		private void ConstructBackend()
		{
           
            connector = new SSLConnector(IP, PORT); //Connect to server!
			writer = new SSLWriter(connector.SslStream);
			streamListener = new SSLListener(connector.SslStream);
			messagehandler = new Messagehandler("Placeholder", connector); //Needs to be changed, see Readme in MessegeHandler class
		}

		// Creates winform thread (STAThread).
		[STAThread] // <- Makes win-forms to run in own thread!
		public void Run() //Run the program
		{
			streamListener.StartListen(); //Start to listen for incomming messages.
            Application.Run(loginWindow);
		}

		private void UserLogin()
		{
			//login logic here
		}

        private void cd_ChatWindowLoaded(object sender, EventArgs e)
        {
            messageList = new List<string>();
            try
            {
                messageList = File.ReadAllLines("MessageLog.txt").ToList();
            }
            catch (Exception)
            {
                chatWindow.AppendTextBox(messageList,"Failed to read previous messages" + System.Environment.NewLine);
            }
        }

        private void cd_OpenRegisterWindow(object sender, EventArgs e)
        {
            registerWindow.ShowDialog();
        }

        private void cd_OpenLoginWindow(object sender, EventArgs e)
        {
            writer.Write(loginWindow.getUsername(), loginWindow.getPassword(), MessageType.login);
        }

        private void cd_ExitWindow(object sender, EventArgs e)
        {
            Application.Exit();
            System.Environment.Exit(1);
        }

        private void cd_ClientRegister(object sender, EventArgs e)
        {
            // Registration of client.
        }
        
        private void cd_RegisterCancel(object sender, EventArgs e)
        {
            registerWindow.Close();
        }

        private void cd_ChatWindowSend(object sender, EventArgs e)
        {
            writer.Write(chatWindow.getTextMessageBox(), "Placeholder Client");
        }

        private void cd_ChatWindowClosed(object sender, EventArgs e)
        {
            TextWriter tw = new StreamWriter("MessageLog.txt");
            for (int i = 0; i < messageList.Count; i++)
            {
                tw.WriteLine(messageList[i]);
            }
            tw.Close();
            Application.Exit();
        }

        private void cd_MessageBoxKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Send the message inside messageBox from chatWindow
                chatWindow.clearMessageBox();
            }

        }

        private void cd_PreviousMessageButtonClicked(object sender, EventArgs e)
        {
            foreach (string s in messageList)
            {
                chatWindow.AppendTextBox(messageList,s + System.Environment.NewLine);
            }
        }
    }
}

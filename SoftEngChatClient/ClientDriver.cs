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

namespace SoftEngChatClient.Controller
{
	class ClientDriver
	{
        int spam;
		private ChatWindow chatWindow;
		private Login loginWindow;
        private Register registerWindow;

        private List<IndividualChatWindow> individualChatWindows;

		private SSLConnector connector;
		private SSLListener streamListener;
		private SSLWriter writer;
		private Messagehandler messagehandler;
        private LogCrypto logCrypto;

        private string username;

        public List<string> messageList;

		private const string IP = "127.0.0.1";	//ServerIP
		private const int PORT = 5300;      //Serverport

        // Creates winform thread (STAThread).
        [STAThread] // <- Makes win-forms to run in own thread!
        public void Run() //Run the program
        {
            streamListener.StartListen(); //Start to listen for incomming messages.
            Application.Run(loginWindow);
        }

		internal void CloseRegWindow()
		{
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
            chatWindow = new ChatWindow();  //Should not handle messages (Only read user input and let backend handle the details)
                                            //Print output for user
            loginWindow = new Login();      //Only responsible for login-functionality (see SRP Principle)
            registerWindow = new Register();
            individualChatWindows = new List<IndividualChatWindow>();
        }

        //Constructs backend modules
        private void ConstructBackend()
        {

            connector = new SSLConnector(IP, PORT); //Connect to server!
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

            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(cd_TimerElapsed);
            timer.Enabled = true;

            loginWindow.RegisterButtonClick += new EventHandler(cd_OpenRegisterWindow);
			loginWindow.LoginButtonClick += new EventHandler(cd_TryLogin);
			loginWindow.ExitButtonClicked += new EventHandler(cd_LoginExitWindow);
			registerWindow.RegisterButtonClick += new EventHandler(cd_ClientRegisterButtonClick);
			registerWindow.CancelButtonClicked += new EventHandler(cd_RegisterWindowCancel);
			chatWindow.sendButtonClicked += new EventHandler(cd_ChatWindowSend);
			chatWindow.chatWindowClosed += new EventHandler(cd_ChatWindowClosed);
			chatWindow.messageBoxKeyReleased += new KeyEventHandler(cd_CWMessageBoxKeyReleased);
			chatWindow.previousMessageButtonClick += new EventHandler(cd_PreviousMessageButtonClicked);
			chatWindow.ChatWindowLoad += new EventHandler(cd_ChatWindowLoaded);
            chatWindow.usernamePressed += new EventHandler(cd_HandleUsernamePressed);
        }

        private void cd_TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (spam >= 0)
            {
                spam--;
            }
        }

        private void cd_HandleUsernamePressed(object sender, EventArgs e)
        {
            var index = chatWindow.listBox1.SelectedItem;
            string username = chatWindow.listBox1.GetItemText(index);

            AddNewIndividualChatWindow(username);
        }
        private void cd_ChatWindowLoaded(object sender, EventArgs e)
        {
            messageList = new List<string>();
            try
            {
                string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\MessageLog.txt";
                byte[] ba = File.ReadAllBytes(filePath);

                var goodString = logCrypto.DecryptBytes(ba);
                chatWindow.AppendTextBox(messageList, goodString);

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
        private void cd_TryLogin(object sender, EventArgs e)
        {
            writer.WriteLogin(MessageType.login, loginWindow.getUsername(), loginWindow.getPassword());
        }
        private void cd_LoginExitWindow(object sender, EventArgs e)
        {
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
        private void cd_ChatWindowSend(object sender, EventArgs e)
        {
            spam++;
            if((chatWindow.getTextMessageBox().Length > 0) && spam < 5)
            {
                {
                    writer.WriteClient(MessageType.client, this.username, "All", chatWindow.getTextMessageBox());
                    chatWindow.AppendTextBox("[ME] : " + chatWindow.getTextMessageBox());
                    chatWindow.clearMessageBox();
                }
            }
            else
            {
                chatWindow.AppendTextBox("[Program] Don´t spam");
            }
           
        }
        private void cd_ChatWindowClosed(object sender, EventArgs e)
        {
            var str = chatWindow.getChatBox();
            var byteArray = logCrypto.EncryptString(str);
            var fs = new FileStream("MessageLog.txt", FileMode.Create, FileAccess.Write);
            fs.Write(byteArray, 0, byteArray.Length);
            fs.Close();
            Application.Exit();
            System.Environment.Exit(1);
        }
        private void cd_PreviousMessageButtonClicked(object sender, EventArgs e)
        {
            foreach (string s in messageList)
            {
                chatWindow.AppendTextBox(messageList, s + System.Environment.NewLine);
            }
        }
        private void cd_CWMessageBoxKeyReleased(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cd_ChatWindowSend(sender, e);
            }
        }

        public void AddNewIndividualChatWindow(string username)
        {
            foreach (IndividualChatWindow icw in individualChatWindows)
            {
                if (icw.getUserName() == username)
                {
                    icw.Show();
                    return;
                }
            }
            individualChatWindows.Add(new IndividualChatWindow(username));
        }
        public void UpdateOnlineList(string str)
        {
            if (chatWindow.InvokeRequired)
            {
                chatWindow.Invoke(new Action<string>(UpdateOnlineList), new object[] { str });
                return;
            }
            string[] usernames;
            usernames = str.Split(':');
            for (int n = chatWindow.listBox1.Items.Count -1; n >= 0; --n)
            {
                chatWindow.listBox1.Items.RemoveAt(n);
            }

            for (int i = 1; i < usernames.Length; i++)
            {
                chatWindow.listBox1.Items.Add(usernames[i]);
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
            loginWindow.Hide();
            chatWindow.Show();
        }

        public void ChatWindowPrint(string sender, string message)
        {
            chatWindow.AppendTextBox("[" + sender + "] : " + message);
        }
    }
}

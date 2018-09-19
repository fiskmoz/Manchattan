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

        private List<IndividualChatWindow> individualChatWindows;

		private SSLConnector connector;
		private SSLListener streamListener;
		private SSLWriter writer;
		private Messagehandler messagehandler;
        private LogCrypto logCrypto;

        private string username;

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
            messagehandler.LoginValid += this.Login;
            messagehandler.ParsedIncommmingMessage += this.ChatWindowPrint;
           
			loginWindow.RegisterButtonClick += new EventHandler(cd_OpenRegisterWindow);
			loginWindow.LoginButtonClick += new EventHandler(cd_OpenLoginWindow);
			loginWindow.ExitButtonClicked += new EventHandler(cd_ExitWindow);
			registerWindow.RegisterButtonClick += new EventHandler(cd_ClientRegister);
			registerWindow.CancelButtonClicked += new EventHandler(cd_RegisterCancel);
			chatWindow.sendButtonClicked += new EventHandler(cd_ChatWindowSend);
			chatWindow.chatWindowClosed += new EventHandler(cd_ChatWindowClosed);
			chatWindow.messageBoxKeyReleased += new KeyEventHandler(cd_MessageBoxKeyReleased);
			chatWindow.previousMessageButtonClick += new EventHandler(cd_PreviousMessageButtonClicked);
			chatWindow.ChatWindowLoad += new EventHandler(cd_ChatWindowLoaded);
            chatWindow.usernamePressed += new EventHandler(cd_HandleUsernamePressed);
            
        }

        private void addNewIndividualChatWindow(string username)
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

        private void addItemsToListBox(string username)
        {
            chatWindow.listBox1.Items.Add(username);
        }

        private void cd_HandleUsernamePressed(object sender, EventArgs e)
        {
            var index = chatWindow.listBox1.SelectedItem;
            string username = chatWindow.listBox1.GetItemText(index);

            addNewIndividualChatWindow(username);
        }

        private void Login(object sender, LoginValid eventArgs)
        {
            if(eventArgs.isValid)
            {
                if (loginWindow.InvokeRequired)
                {
                    loginWindow.Invoke(new Action<object, LoginValid>(Login), new object[] { sender, eventArgs });
                    return;
                }
                username = loginWindow.getUsername();
                loginWindow.Hide();
                chatWindow.Show();
            }
        }
        
        private void ChatWindowPrint(object sender, ParsedIncommingMessage eventArgs)
        {
            chatWindow.AppendTextBox("["+eventArgs.sender+"] : " + eventArgs.message);
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

            //Change to something different.
            string input = "hejhejjkjdueoplikmnakduehgjdmnju";
            byte[] array = Encoding.ASCII.GetBytes(input);
            logCrypto.SetNewKey(array);
		}

		// Creates winform thread (STAThread).
		[STAThread] // <- Makes win-forms to run in own thread!
		public void Run() //Run the program
		{
			streamListener.StartListen(); //Start to listen for incomming messages.
            Application.Run(loginWindow);
		}

        //
		private void UserLogin()
		{
			//login logic here
		}


        private void cd_ChatWindowLoaded(object sender, EventArgs e)
        {
            messageList = new List<string>();
            try
            {
                /*        
                var fs = new FileStream("MessageLog.txt", FileMode.Open);
                fs.Read(ba, 0, 20);
                */

                string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\MessageLog.txt";
                byte[] ba = File.ReadAllBytes(filePath);

                var goodString = logCrypto.DecryptBytes(ba);
                chatWindow.AppendTextBox(messageList, goodString);

                //messageList = File.ReadAllLines("MessageLog.txt").ToList();
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
            //writer.Write(loginWindow.getUsername(), loginWindow.getPassword(), MessageType.login);
            writer.WriteLogin(MessageType.login, loginWindow.getUsername(), loginWindow.getPassword());
            //TODO: change this back
        }

        private void cd_ExitWindow(object sender, EventArgs e)
        {
            Application.Exit();
            System.Environment.Exit(1);
        }

        private void cd_ClientRegister(object sender, EventArgs e)
        {
            // Registration of client.
            //writer.Write("Bertil", MessageType.login);
            //writer.WriteClient(MessageType.client,this.userna)



        }
        
        private void cd_RegisterCancel(object sender, EventArgs e)
        {
            registerWindow.Close();
        }

        private void cd_ChatWindowSend(object sender, EventArgs e)
        {
            if(chatWindow.getTextMessageBox().Length > 0)
            {
                //writer.Write(chatWindow.getTextMessageBox(), "Placeholder Client");
                writer.WriteClient(MessageType.client, this.username, "All", "Placeholder message");
                chatWindow.AppendTextBox("[ME] : " + chatWindow.getTextMessageBox());
                chatWindow.clearMessageBox();
            }
        }

        private void cd_ChatWindowClosed(object sender, EventArgs e)
        {
            //TextWriter tw = new StreamWriter("MessageLog.txt");

            var str = chatWindow.getChatBox();

            str = str + "hejhejhej";

            var byteArray = logCrypto.EncryptString(str);

            var fs = new FileStream("MessageLog.txt", FileMode.Create, FileAccess.Write);
            fs.Write(byteArray, 0, byteArray.Length);

            fs.Close();

            /*
            string[] lines = str.Split(
            new[] { Environment.NewLine },
            StringSplitOptions.None
            );

            for (int i = 0; i < lines.Length; i++)
            {
                tw.WriteLine(lines[i]);
            }
            tw.Close();
            */
            Application.Exit();
        }

        private void cd_PreviousMessageButtonClicked(object sender, EventArgs e)
        {
            foreach (string s in messageList)
            {
                chatWindow.AppendTextBox(messageList, s + System.Environment.NewLine);
            }
        }

        private void cd_MessageBoxKeyReleased(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cd_ChatWindowSend(sender, e);
            }
        }

        public void UpdateOnlineList(string str)
        {
            string[] usernames;
            usernames = str.Split(':');
            for (int i = 1; i < usernames.Length; i++)
            {
                addItemsToListBox(usernames[i]);
            }
        }
    }
}

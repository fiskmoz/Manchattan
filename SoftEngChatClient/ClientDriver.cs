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
        private LoginWindowDriver loginWindowDriver;
		private SSLConnector connector;
		private SSLListener streamListener;
		private SSLWriter writer;
		private Messagehandler messagehandler;
        private Cryptography logCrypto;

		private const string IP = "127.0.0.1";	//ServerIP
		private const int PORT = 5300;      //Serverport

        // Creates winform thread (STAThread).
        [STAThread] // <- Makes win-forms to run in own thread!
        public void Run() //Run the program
        {
            
			streamListener.StartListen();
			Application.Run(loginWindowDriver.GetLoginForm());
		}

		// When creating the ClientDriver in main (program.cs)
		public ClientDriver()
		{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConstructBackend();
            chatWindowDriver = new ChatWindowDriver(writer, logCrypto);
            loginWindowDriver = new LoginWindowDriver(writer);
            SetupListeners();
            

        }
        //Constructs backend modules
        private void ConstructBackend()
        {
            connector = new SSLConnector(IP, PORT); //Connect to server!
			connector.Connect();
            writer = new SSLWriter(connector.SslStream);
            streamListener = new SSLListener(connector.SslStream);
            messagehandler = new Messagehandler(); 
            logCrypto = new Cryptography();

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
        }

        private void ChatWindowLogout(object o, EventArgs e)
        {
            connector.Connect();
            writer.stream = connector.SslStream;
            streamListener.stream = connector.SslStream;
            loginWindowDriver.ShowLoginWindow();
        }
    }
}

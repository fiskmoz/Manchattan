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
using SoftEngChatClient.P2P;

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
        private ClientCrypto logCrypto;
		private P2PConnector p2pConnector;

        public static string globalUsername;
        

		private const string IP = Constants.ip;	//ServerIP
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
            logCrypto = new ClientCrypto();
			p2pConnector = new P2PConnector();
        }

        //Sets up listeners for the different events.
        private void SetupListeners()
		{
			messagehandler.Subscribe(streamListener);
			loginWindowDriver.Subscribe(messagehandler);
			chatWindowDriver.Subscribe(messagehandler, p2pConnector);
			chatWindowDriver.restart += new EventHandler(ChatWindowLogout);
			p2pConnector.Subscribe(messagehandler);
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

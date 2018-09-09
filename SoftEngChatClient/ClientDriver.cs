using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		private SSLConnector connector;
		private SSLListener streamListener;
		private SSLWriter writer;
		private Messagehandler messagehandler;

		private const string IP = "127.0.0.1";	//ServerIP
		private const int PORT = 5300;		//Serverport

		public ClientDriver()
		{
			ConstructGUI();
			ConstructBackend();
		}

		private void ConstructBackend()
		{
			connector = new SSLConnector(IP, PORT); //Connect to server!
			writer = new SSLWriter(connector.SslStream);
			streamListener = new SSLListener(connector.SslStream);
			messagehandler = new Messagehandler("Placeholder", connector); //Needs to be changed, see Readme in MessegeHandler class

			streamListener.IncommingMessage += messagehandler.HandleIncommingMessage; //Tell messagehandler to listen for IncommingMessage Events raised by streamlistener

		}

		// Creates winform thread (STAThread).
		[STAThread]
		public void Run() //Run the program
		{
			streamListener.StartListen(); //Start to listen for imcomming messages.

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(loginWindow);
		}
		
		private void ConstructGUI()
		{
			chatWindow = new ChatWindow();
			loginWindow = new Login();
		}
	}
}

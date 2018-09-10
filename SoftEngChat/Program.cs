using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using SoftEngChat.Model.SSLCommunication;

namespace SoftEngChat
{
    class ChatClient
    {
        public TcpClient Client { get; set; }
        public ChatServer Server { get; set; }
        public Thread MessageThread { get; set; }
        public ValidateUser validateUser;

        public ChatClient(TcpClient client, ChatServer parent)
        {
            Client = client;
            Server = parent;
            MessageThread = new Thread(handle_message);
            validateUser = new ValidateUser();
            MessageThread.Start();
        }
        public void handle_message()
        {
            var stream = Client.GetStream();
            byte[] buffer = new byte[Client.ReceiveBufferSize];
            while (Client.Connected)
            {
                int bytesRead;
                try
                {
                    bytesRead = stream.Read(buffer, 0, Client.ReceiveBufferSize);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                if (bytesRead > 0)
                {
                    string test = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    if (test.Contains("1234|"))
                    {
                        Console.WriteLine("Test contains!");
                        var username = new StringBuilder();
                        var password = new StringBuilder();
                        bool flag = false;
                        for (int i = 5; i < test.Length; i++)
                        {
                            if (test[i] == '|')
                            {
                                flag = true;
                            }
                            else if(flag == true)
                            {
                                password.Append(test[i]);
                            }
                            else if(flag == false)
                            {
                                username.Append(test[i]);
                            }
                        }

                        Console.WriteLine("Username:" + username.ToString() + " Password: " + password.ToString());

                        if(validateUser.validate(username.ToString(), password.ToString()) == "true")
                        {
                            SendMessage("true");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Received Message " + test);
                        try
                        {
                            Server.SendAll(test);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
        }

        internal void SendMessage(string message)
        {
            Console.WriteLine("Send Message: " + message);
            if(Client.Connected)
            {
                Client.GetStream().Write(Encoding.ASCII.GetBytes(message), 0, message.Length);
            }
        }
    }

    class ChatServer
    {
        private object clients_lock;
        public List<ChatClient> Clients { get; private set; }
        public ChatServer(IPAddress ipAddress, int port)
        {
            clients_lock = new object();
            Clients = new List<ChatClient>();
            var listener = new TcpListener(ipAddress, port);
            listener.Start();
            while (true)
            {
                var client = listener.AcceptTcpClient();
                Console.WriteLine("Client Connected");
                lock (clients_lock) Clients.Add(new ChatClient(client, this));
            }
        }

        public void SendAll(string message)
        {
            foreach (var client in Clients)
            {
                client.SendMessage(message);
            }
        }

    }

    class Program
    {
        public static void Main(string[] args)
        {
            DatabaseManegement DBtest = new DatabaseManegement();
            List<User> userList = new List<User>();
            DBtest.DBwrite(userList);
            DBtest.DBread();
			SSLServer server = new SSLServer(IPAddress.Loopback, 5300);
            //ChatServer server = new ChatServer(IPAddress.Loopback, 5300);
        }
    }
}

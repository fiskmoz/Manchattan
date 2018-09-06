using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SoftEngChat
{
    class ChatClient
    {
        public TcpClient Client { get; set; }
        public ChatServer Server { get; set; }
        public Thread MessageThread { get; set; }
        public ChatClient(TcpClient client, ChatServer parent)
        {
            Client = client;
            Server = parent;
            MessageThread = new Thread(handle_message);
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
                    Console.WriteLine("Received Message " + test);
                    try { 
                        Server.SendAll(test);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        internal void SendMessage(string message)
        {
            Console.WriteLine("Send Message " + message);
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
        static void Main(string[] args)
        {
            ChatServer server = new ChatServer(IPAddress.Loopback, 5300);
        }
    }
}

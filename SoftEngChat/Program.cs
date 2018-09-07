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
            DBtest.DBwrite();
            DBtest.DBread();
            
            ChatServer server = new ChatServer(IPAddress.Loopback, 5300);
        }
    }
}

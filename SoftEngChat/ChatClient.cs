using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftEngChat
{
    class ChatClient
    {
        public User UserInfo { get; set; }
        public TcpClient Client { get; set; }
        public ChatServer Server { get; set; }
        public Thread MessageThread { get; set; }
        public ChatClient(TcpClient client, ChatServer parent)
        {
            Client = client;
            Server = parent;
            MessageThread = new Thread(Handle_message);
            MessageThread.Start();
        }
        public void Handle_message()
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
        internal void SendMessage(string message)
        {
            Console.WriteLine("Send Message " + message);
            if (Client.Connected)
            {
                Client.GetStream().Write(Encoding.ASCII.GetBytes(message), 0, message.Length);
            }
        }
    }

}

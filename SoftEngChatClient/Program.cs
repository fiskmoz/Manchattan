using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftEngChatClient
{
    class Program
    {
        static TcpClient Client;
        static void handle_message()
        {
            var stream = Client.GetStream();
            byte[] buffer = new byte[Client.ReceiveBufferSize];
            while (Client.Connected)
            {
                int bytesRead = stream.Read(buffer, 0, Client.ReceiveBufferSize);
                if (bytesRead > 0)
                {
                    string test = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine(test);
                    Console.Write("# ");
                }
            }
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(handle_message);
            Client = new TcpClient();
            bool quit = false;
            Client.Connect("127.0.0.1", 5300);
            var stream = Client.GetStream();
            thread.Start();
            while (!quit)
            {
                
                Console.Write("# ");
                string cmd = Console.ReadLine();
                if (cmd == "quit")
                    quit = true;
                stream.Write(Encoding.ASCII.GetBytes(cmd), 0, cmd.Length);
                
            }
            
            Client.Close();
        }
    }
}

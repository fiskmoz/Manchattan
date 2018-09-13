﻿using System;
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
    class Program
    {
        public static void Main(string[] args)
        {
            DatabaseManegement DBtest = new DatabaseManegement();
            //DBtest.DBread();
			SSLServer server = new SSLServer(IPAddress.Loopback, 5300);
            //ChatServer server = new ChatServer(IPAddress.Loopback, 5300);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftEngChat.Model.SSLCommunication
{
    class SSLClient
    {
        public User UserInfo { get; set; }
		public SSLListener listener;
		public SSLWriter writer;
		public SslStream stream;
		private SSLConnector server;

        public SSLClient(SslStream stream, SSLConnector connector)
        {
			server = connector;
			this.stream = stream;
			listener = new SSLListener(stream);
			writer = new SSLWriter(stream, server);
		}
    }

}

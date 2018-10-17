using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient.P2P
{
    class P2PWriter
    {
        NetworkStream netStream;
        public P2PWriter(NetworkStream netStream)
        {
            this.netStream = netStream;
        }

        private void SendMessage(string outgoing)
        {
            byte[] outgoingBytes = Encoding.UTF8.GetBytes(outgoing);
            netStream.Write(outgoingBytes, 0, outgoingBytes.Length);
        }

    }
}

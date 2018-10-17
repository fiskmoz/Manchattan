using SoftEngChatClient.Model.SSLCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient.P2P
{
	internal class P2PIndividualChatDriver : IndividualChatDriver
	{
		NetworkStream netstream;
		P2PListener listener;
		P2PWriter writer;

		public P2PIndividualChatDriver(SSLWriter sslWriter, string Username, string Receiver, FileManager fm, NetworkStream netstream)
			: base(sslWriter, Username, Receiver, fm)
		{
			this.netstream = netstream;
			listener = new P2PListener(netstream);
			writer = new P2PWriter(netstream);
		}
		

	}
}

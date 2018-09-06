using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient.Model.SSLCommunication
{
	class SSLWriter
	{
		private SslStream sslStream;

		public SSLWriter(SslStream stream)
		{
			sslStream = stream;
		}
	}
}

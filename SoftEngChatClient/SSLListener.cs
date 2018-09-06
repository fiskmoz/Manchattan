using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient.Model.SSLCommunication
{
	class SSLListener
	{
		private SslStream sslStream;

		public SSLListener(SslStream sslStream)
		{
			this.sslStream = sslStream;
		}
	}
}

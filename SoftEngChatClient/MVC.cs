using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient
{
	namespace Model
	{
		namespace SSLCommunication
		{
			public enum MessageType
			{
				loginUserName = 0, loginUserPassword = 1, client = 2, login = 3, //Outgoing
				loginACK = 4, incommingClient = 5   //Incomming
			}
		}
	}
	namespace View
	{

	}
	namespace Controller { }
}

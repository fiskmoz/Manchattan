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
				reigster = 0,
                registerACK = 1,
                client = 2,
                login = 3,
				loginACK = 4,
                logout = 5,
                onlineList = 6
			}
		}
	}
	namespace View
	{

	}
	namespace Controller { }
}

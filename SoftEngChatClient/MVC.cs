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
				reigster = 0, // "0:username:mail:pass:name:surname"
                registerACK = 1, // "1:0/1"
                client = 2, // "2:sender:receiver:message"
                login = 3,  // "3:username:password"
				loginACK = 4,  // "4:0/1"
                logout = 5,  // "5: 1
                onlineList = 6  // 6:A:B:C:D"
			}
		}
	}
	namespace View
	{

	}
	namespace Controller { }
}

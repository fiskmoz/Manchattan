namespace SoftEngChat
{
    namespace Model
    {
        public enum MessageType
        {
            register = 0, // "0:username:mail:pass:name:surname"
            registerACK = 1, // "1:0/1"
            client = 2, // "2:sender:receiver:message"
            login = 3,  // "3:username:password"
            loginACK = 4,  // "4:0/1"
            logout = 5,  // "5:1
            onlineList = 6,  // 6:1/0:A:B:C:D"
            friendRequest = 7, // 7:sender:receiver
            friendReponse = 8, // 8:sender:receiver:0/1
            onlineStatus = 9, // 9:1/0:username
            establishP2P = 10, // 10:sender:receiver
            incommingP2P = 11, // 11:sender:port:key
            outgoingP2P = 12, // 12:receiver:port:key
            statusUpdate = 13 // 13:sender:receiver:status
        }
        namespace SSLCommunication { }
	}
	namespace View { }
	namespace Controller { }
}

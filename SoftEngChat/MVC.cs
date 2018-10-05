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
            logout = 5,  // "5: 1
            onlineList = 6,  // 6:0/1:A:B:C:D"
            friendRequest = 7,   // 7:sender:receiver
            friendResponse = 8, //   8:sender:receiver:(0/1)     (Decline/Accept)
            onlineStatus = 9 // 9:0/1:name
        }
        namespace SSLCommunication { }
	}
	namespace View { }
	namespace Controller { }
}

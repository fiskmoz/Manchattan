Made in 2 months by team 4, Software Engineering, Karlstad University, 2018.
Made with windows, winforms and C# using Visual studio 2017.

Supported features: 
- P2P messaging
- Server based messaging
- Encrypted messagning
- Registration
- Friends and requests
- Global chat
- Send file
- Userbase search
- Emojis

Messagetypes: 
- 0: Register        |   0:username:mail:pass:name:surname
- 1: Register ACK    |   1:(0/1)
- 2: Client Message  |   2:sender:receiver:message
- 3: Login Message   |   3:username:password
- 4: Login ACK       |   4:(0/1):userkey
- 5: Logout Message  |   5:1
- 6: Onlinelist      |   6:(0/1):A:B:C:D           (Offline/online list)
- 7: FriendRequest   |   7:sender:receiver
- 8: FriendResponse  |   8:sender:receiver:(0/1)   (Decline/Accept)
- 9: OnlineStatus    |   9:(0/1):UserName                   (Offline/Online)
- 10:EstablishP2P    |   10:sender:receiver
- 11:IncommingP2P    |   11:sender:port:key
- 12:OutgoingP2P     |   12:receiver:port:key
- 13:StatusUpdate    |   13:sender:receiver:status

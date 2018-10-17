# HEJ

### Minnesregler

#### Messagetypes 
#### 0: Register        |   0:username:mail:pass:name:surname
#### 1: Register ACK    |   1:(0/1)
#### 2: Client Message  |   2:sender:receiver:message
#### 3: Login Message   |   3:username:password
#### 4: Login ACK       |   4:(0/1):userkey
#### 5: Logout Message  |   5:1
#### 6: Onlinelist      |   6:(0/1):A:B:C:D           (Offline/online list)
#### 7: FriendRequest   |   7:sender:receiver
#### 8: FriendResponse  |   8:sender:receiver:(0/1)   (Decline/Accept)
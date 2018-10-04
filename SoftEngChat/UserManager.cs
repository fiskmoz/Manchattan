using System;
using System.Collections.Generic;

namespace SoftEngChat
{
    class UserManager
    {
        private const string FILE_NAME = "DB.txt";
		static string filePath;
        private List<User> userList;
        private DatabaseManegement db = new DatabaseManegement();

        public UserManager()
        {
			filePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + FILE_NAME;
			userList = db.DBread(filePath);
		}

        //Validate user from login and checks with users on database.
        public bool ValidateUser(string userIn, string passwordIn)
        {
            DatabaseManegement DB = new DatabaseManegement();
            List<User> userlist = DB.DBread(filePath);
            foreach (var User in userlist)
            {
                Console.WriteLine("Login: " + "|"+userIn+"|" + " " + "|"+passwordIn+"|" + ":" + " |"+User.userName+"|" + " " + User.password);
                if ((User.userName == userIn || User.mail == userIn) && User.password == passwordIn)
                {
                    Console.WriteLine(User.userName + User.password);
                    return true;
                }
            }
            Console.WriteLine("returning false");
            return false;
        }

        //Add user to database from Register.
		internal bool AddUser(List<string> newUser)
		{
			foreach (var user in userList)
			{
				if (user.userName == newUser[0] || user.mail == newUser[1])
				{
					return false;
				}
			}

			userList.Add(new User(newUser));
			db.DBwrite(userList, filePath);
			return true;
		}
	}
}

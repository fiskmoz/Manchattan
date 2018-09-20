using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChat
{
    class UserManager
    {

        private const string FILE_NAME = "DB.txt";
		static string filePath;
        private List<User> userList;
        private DatabaseManegement db; 

        public UserManager()
        {
			db = new DatabaseManegement();
			filePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + FILE_NAME;
			userList = db.DBread(filePath);
		}

        //Remove user from database write back to database. This also 
        //returns a list, dont know if it is nesesary. But it thus for now.
        public List<User> RemoveUser(string name, string password)
        {
            userList = db.DBread(filePath);
            ValidateUser validate = new ValidateUser(FILE_NAME);
            
            foreach(var user in userList)
            {
                if(validate.validate(user.UserName, user.Password))
                {
                    userList.Remove(user);
                }
            }

            db.DBwrite(userList,filePath);

            return userList;
        }

        //Validate user from login and checks with users on database.
        public bool validateUser(string userIn, string passwordIn)
        {
            DatabaseManegement DB = new DatabaseManegement();
            List<User> userlist = DB.DBread(filePath);
            foreach (var User in userlist)
            {
                Console.WriteLine("Login: " + "|"+userIn+"|" + " " + "|"+passwordIn+"|" + ":" + " |"+User.UserName+"|" + " " + User.Password);
                if ((User.UserName == userIn || User.Mail == userIn) && User.Password == passwordIn)
                {
                    Console.WriteLine(User.UserName + User.Password);
                    return true;
                }
                    
            }
            Console.WriteLine("returning false");
            return false;
        }

		internal bool AddUser(List<string> newUser)
		{
			foreach (var user in userList)
			{
				if (user.UserName == newUser[0] && user.Mail == newUser[1])
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

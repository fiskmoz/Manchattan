using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChat
{
    class UserManager
    {

        private const String FILE_NAME = "DB.txt";
		static string filePath;
        private List<User> userList;
        private DatabaseManegement db; 

        public UserManager()
        {

			filePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + FILE_NAME;
			userList = db.DBread(filePath);
		}

        //Add a new user, when registrate and write to database.
        public void AddUser(string name, string mail, string password)
        {
            //userList = db.DBread(filePath);
            foreach(var user in userList)
            {
                if(user.name != name)
                {
                    userList.Add(new User(name, mail, password));
                    db.DBwrite(userList,filePath);
                } 
                else
                {
                    Console.WriteLine("User exist");
                }
            }
        }

        //Remove user from database write back to database. This also 
        //returns a list, dont know if it is nesesary. But it thus for now.
        public List<User> RemoveUser(string name, string password)
        {
            userList = db.DBread(filePath);
            ValidateUser validate = new ValidateUser();
            
            foreach(var user in userList)
            {
                if(validate.validate(user.name, user.password) == "true")
                {
                    userList.Remove(user);
                }
            }

            db.DBwrite(userList,filePath);

            return userList;
        }

        //Validate user from login and checks with users on database.
        public string validateUser(string userIn, string passwordIn)
        {
            DatabaseManegement DB = new DatabaseManegement();
            List<User> userlist = DB.DBread(filePath);
            foreach (var User in userlist)
            {
                Console.WriteLine("Login: " + "|"+userIn+"|" + " " + "|"+passwordIn+"|" + ":" + " |"+User.name+"|" + " " + User.password);
                if ((User.name == userIn || User.mail == userIn) && User.password == passwordIn)
                {
                    Console.WriteLine(User.name + User.password);
                    return "true";
                }
                    
            }
            Console.WriteLine("returning false");
            return "false";
        }

		internal bool AddUser(List<string> newUser)
		{
			foreach (var user in userList)
			{
				if (user.name == newUser[0] && user.mail == newUser[1])
				{
					return false;
				}
			}

			userList.Add(new User(newUser[0], newUser[1], newUser[2]));
			db.DBwrite(userList, filePath);
			return true;
		}
	}
}

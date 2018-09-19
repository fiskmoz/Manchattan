using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChat
{
    class UserManager
    {

        static String fileName = "DB.txt";
        static string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName;
        private List<User> userList;
        private DatabaseManegement db; 

        public UserManager()
        {
            
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
                if ((User.name == userIn || User.mail == userIn) && User.password == passwordIn)
                    return "true" ;
            }
            return "false";
        }
    }
}

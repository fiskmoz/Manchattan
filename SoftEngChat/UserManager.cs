using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChat
{
    class UserManager
    {
        private List<User> userList;
        private DatabaseManegement db = new DatabaseManegement();
        public UserManager()
        {
            userList = db.DBread();
        }

        //Add a new user, when registrate.
        public void AddUser(string name, string mail, string password)
        {
            userList.Add(new User(name, mail, password));
            db.DBwrite(userList);
        }

    }
}

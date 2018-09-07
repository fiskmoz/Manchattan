using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChat
{
    class ValidateUser
    {
        List<User> userlist;
        public ValidateUser()
        {
            DatabaseManegement DB = new DatabaseManegement();
            userlist = DB.DBread();

        }
        public Boolean validate(string userIn, string passwordIn)
        {
            foreach(var User in userlist)
            {
                if (User.name == userIn && User.password == passwordIn)
                    return true;
            }
            return false;
        }
    }
}

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
        public ValidateUser(string filePath)
        {
            DatabaseManegement DB = new DatabaseManegement();
            userlist = DB.DBread(filePath);

        }
        public bool validate(string userIn, string passwordIn)
        {
            foreach(var User in userlist)
            {
                if ((User.UserName == userIn || User.mail == userIn) && User.password == passwordIn)
                    return true;
            }
            return false;
        }
    }
}

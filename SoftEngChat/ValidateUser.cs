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
        string flag1 = "true";
        string flag0 = "false";
        public ValidateUser()
        {
            DatabaseManegement DB = new DatabaseManegement();
            //userlist = DB.DBread();

        }
        public string validate(string userIn, string passwordIn)
        {
            foreach(var User in userlist)
            {
                if ((User.name == userIn || User.mail == userIn) && User.password == passwordIn)
                    return flag1;
            }
            return flag0;
        }
    }
}

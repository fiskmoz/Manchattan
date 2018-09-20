using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftEngChat;

namespace RegisterTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            //UserManager UM = new UserManager();
            List<string> testUser = new List<string>();
            string username, mail, password, firstname, lastname;
            username = "AuntyLover";
            mail = "Jon_Snow@kingofthenorth.com";
            password = "youknownothing";
            firstname = "Jon";
            lastname = "Snow";
            Console.WriteLine("*** Register System Testing***");
            Console.WriteLine("The User is: " + username + "," + mail + "," + password + "," + firstname + "," + lastname);
            testUser.Add(username);
            testUser.Add(mail);
            testUser.Add(password);
            testUser.Add(firstname);
            testUser.Add(lastname);


        }
    }
}

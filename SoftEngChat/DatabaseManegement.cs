using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DatabaseManegement
    {
        User test;
        public void DBwrite()
        {

            // Test user
            test = new User();

            test.name = "Bob";
            test.password = "girls";
            test.mail = "bob@pornhub.com";
            
            // Output to file
            using(StreamWriter file = File.CreateText(@"C:\Users\Nikla\Desktop\DB.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, test);
            }
          

        }
        public void DBread()
        {
            // Input from file to struct
            User inputuser = new User();
            using(StreamReader file = File.OpenText(@"C:\Users\Nikla\Desktop\DB.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                inputuser = (User)serializer.Deserialize(file, typeof(User));
            }
            Console.WriteLine(inputuser.name +" " +  inputuser.password +" "+ inputuser.mail);
        }
    }
}

//using Newtonsoft.Json;
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
        public struct temp
        {
            int ID;
            String name;
            String password;
            String mail;
        }
        public void DBwrite()
        {

            test = new User();

            test.name = "Bob";
            test.password = "girls";
            test.mail = "bob@pornhub.com";



            //File.WriteAllText(@"DB.json", JsonConvert.SerializeObject("name"));
            
            using(StreamWriter file = File.CreateText(@"C:\Users\Nikla\Desktop\DB.txt"))
            {
      //          JsonSerializer serializer = new JsonSerializer();
         //      serializer.Serialize(file, test);
            }
        }
    }
}

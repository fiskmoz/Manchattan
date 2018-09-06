using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class JsonItem
    {
        public string Html { get; set; }
    }
    public class DatabaseManegement
    {
        User[] test = new User[2];
        User[] inputuser = new User[2];
        public void DBwrite()
        {

            // Test user

            test[0] = new User();
            test[0].name = "Bob";
            test[0].password = "girls";
            test[0].mail = "bob@pornhub.com";

            test[1] = new User();
            test[1].name = "Alice";
            test[1].password = "boys";
            test[1].mail = "alice@mylittlepony.com";

            // Output to file
            using (StreamWriter file = File.CreateText(@"C:\Users\Nikla\Desktop\DB.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, test);
            }
          

        }
        public void DBread()
        {
            // Input from file to struct
            inputuser[0] = new User();
            inputuser[1] = new User();

            //List<Dictionary<string, string>> obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(file);

            using (StreamReader file = File.OpenText(@"C:\Users\Nikla\Desktop\DB.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                inputuser[0] = (User)serializer.Deserialize(file, typeof(User));

            }
            Console.WriteLine("User 1: " +inputuser[0].name + " " + inputuser[0].password +" "+ inputuser[0].mail);
            Console.WriteLine("User 2: " +inputuser[1].name + " " + inputuser[1].password + " " + inputuser[1].mail);
        }
    }
}

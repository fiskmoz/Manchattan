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
        //File path where the login file appears.
        static String fileName = "DB.txt";
        static String filePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName;

        User[] test = new User[2];
        User[] inputuser = new User[2];

        //Database constructor, it creates a file with all login credentials 
        public DatabaseManegement()
        {
            if(!File.Exists(filePath))
            {
                try
                {
                    File.Create(filePath);
                }
                catch(Exception e)
                {
                    e.GetBaseException();
                    Console.WriteLine("Couldnt create file");
                }
            }   
        }
        

        //Byt ut till DBWrite(String fileName) Bättre mer generisk och man 
        //Kan slänga in vilken fil som helst i det.
        public void DBwrite()
        {
            test[0] = new User();
            test[0].name = "Bob";
            test[0].password = "girls";
            test[0].mail = "bob@pornhub.com";

            test[1] = new User();
            test[1].name = "Alice";
            test[1].password = "boys";
            test[1].mail = "alice@mylittlepony.com";

            //File.WriteAllText(@"DB.json", JsonConvert.SerializeObject("name"));
            try
            {
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, test);
                    Console.WriteLine(filePath);
                }

            }
            catch (Exception e)
            {

                e.GetBaseException();
                Console.Write("Dont work");
            }
            
          

        }

        //public void DBread(String fileName)
        public void DBread()
        {
            // Input from file to struct
            inputuser[0] = new User();
            inputuser[1] = new User();

            //List<Dictionary<string, string>> obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(file);

            using (StreamReader file = File.OpenText(filePath))
            {
                //JsonSerializer serializer = new JsonSerializer();
                //inputuser[0] = (User)serializer.Deserialize(file, typeof(User));
                string json = file.ReadToEnd();
                List<User> user = JsonConvert.DeserializeObject<List<User>>(json);

                foreach (var User in user)
                {
                    Console.WriteLine(User.name);
                }
            }

           


            // Console.WriteLine("User 1: " +inputuser[0].name + " " + inputuser[0].password +" "+ inputuser[0].mail);
            //Console.WriteLine("User 2: " +inputuser[1].name + " " + inputuser[1].password + " " + inputuser[1].mail);
        }
    }
}

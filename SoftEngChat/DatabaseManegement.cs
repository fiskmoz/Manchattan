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
        //File path where the login file appears.
        static String fileName = "DB.txt";
        static String filePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName;

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

        User test;
        
        public void DBwrite()
        {

            // Test user
            test = new User();

            test.name = "Bob";
            test.password = "girls";
            test.mail = "bob@pornhub.com";



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
            catch(Exception e)
            {
              
                e.GetBaseException();
                Console.Write("Dont work");
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

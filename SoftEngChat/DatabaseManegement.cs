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
    }
}

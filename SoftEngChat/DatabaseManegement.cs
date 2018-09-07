using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace SoftEngChat
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
        List<User> user;

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
            var tester = new User("Anders", "maejfa", "1231293");
            var tester2 = new User("Nicklas", "mdfmsdkf", "123123");
            List<User> a = new List<User>();
            a.Add(tester);
            a.Add(tester2);
            

            //File.WriteAllText(@"DB.json", JsonConvert.SerializeObject("name"));
            try
            {
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, a);
                    Console.WriteLine(filePath);
                }

            }
            catch (Exception e)
            {
                e.GetBaseException();
                Console.Write("Dont work");
            }
        }

        //Reads from databas(textfile) and returns a list of users.
        public List<User> DBread()
        {   
            try
            {
                using (StreamReader file = File.OpenText(filePath))
                {
                    string json = file.ReadToEnd();
                    user = JsonConvert.DeserializeObject<List<User>>(json);
                }
            }
            catch(Exception e)
            {
                e.GetBaseException();
            } 
            
            return user;
        }
    }
}

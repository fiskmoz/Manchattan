using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        static string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName;
        List<User> user;

        //Database constructor, it creates a file with all login credentials 
        public DatabaseManegement()
        {
            
                CreateFile();
            

        }

        public void CreateFile()
        {
            var tester = new User("Anders", "maejfa", "1231293");
            var tester2 = new User("Nicklas", "mdfmsdkf", "123123");
            user.Add(tester);
            user.Add(tester2);

            try
            {
                File.Create(filePath);
            }
            catch (Exception e)
            {
                e.GetBaseException();
                Console.WriteLine("Couldnt create file");
            }
            
            File.Delete(filePath);
            Console.WriteLine( File.Exists(filePath));
        }
        

        //Byt ut till DBWrite(String fileName) Bättre mer generisk och man 
        //Kan slänga in vilken fil som helst i det.
        public void DBwrite(List<User> userList)
        {
            userList = user;

            



            //File.WriteAllText(@"DB.json", JsonConvert.SerializeObject("name"));
            try
            {
                using (StreamWriter file = File.AppendText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, userList);
                    Console.WriteLine(filePath);
                }
            }
            catch(Exception e)
            {
                e.GetBaseException();
            }
        }

        //Reads from databas(textfile) and returns a list of users.
        public List<User> DBread()
        {
            while (!File.Exists(filePath))
            {
                CreateFile();
            }

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
                Console.WriteLine("Dont work, DB read");
                    
            } 
            
            return user;
        }
    }
}

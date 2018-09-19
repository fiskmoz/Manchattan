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
            user = new List<User>();
            if (!File.Exists(filePath))
            {
                TestUsers();
                DBInitWrite();
            }
        }

        //Test function adds users 
        public void TestUsers()
        {
            var tester = new User("Anders", "maejfa", "112");
            var tester2 = new User("Nicklas", "mdfmsdkf", "123123");
            var tester3 = new User("name", "email", "pass");
            user.Add(tester);
            user.Add(tester2);
            user.Add(tester3);
        }
        

        //Append a list of users in db.txt files, with the help of JSON.
        public void DBwrite(List<User> userList, string filePath)
        {
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
                Console.WriteLine("DBWrite Exception" + e.ToString());
            }
        }

        // Writes the test users to the database if it does not already exsist.
        private void DBInitWrite()
        {
            try
            {
                using (StreamWriter file = File.AppendText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, user);
                    Console.WriteLine(filePath);
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
                Console.WriteLine("Could not create initial users");
            }
        }

        //Reads from databas(textfile) and returns a list of users.
        public List<User> DBread(String filePath)
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
                Console.WriteLine("Dont work, DB read"+ e.ToString());
                    
            } 
            
            return user;
        }
    }
}

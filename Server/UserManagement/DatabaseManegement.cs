﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Server
{
    public class JsonItem
    {
        public string Html { get; set; }
    }
    public class DatabaseManegement
    {
        //File path where the login file appears.
        private static readonly string fileName = "DB.txt";
        private static string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName;
        private List<User> user;

        //Database constructor, it creates a file with all login credentials 
        public DatabaseManegement()
        {
            user = new List<User>();
            if (!File.Exists(filePath))
            {
                DBInitWrite();
            }
        }

        //Append a list of users in db.txt files, with the help of JSON.
        public void DBwrite(List<User> userList, string filePath)
        {
            //File.WriteAllText(@"DB.json", JsonConvert.SerializeObject("name"));
            try
            {
                // using (StreamWriter file = File.AppendText(filePath))
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, userList);
                    //Console.WriteLine(filePath);
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
            List<string> info = new List<string>
            {
                "Admin",
                "mail",
                "112",
                "Admin",
                "Adminson"
            };
            ServerCrypto sc = new ServerCrypto();
            info[2] = sc.Sha256_hash(info[2]);
            User adminUser = new User(info);
            user.Add(new User(info));

            List<string> info2 = new List<string>
            {
                "Getman",
                "getmail",
                "112",
                "Get",
                "Mansson"
            };
            info2[2] = sc.Sha256_hash(info2[2]);
            user.Add(new User(info2));

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
           
					try
					{
						user = JsonConvert.DeserializeObject<List<User>>(json);
					}
					catch(Exception e)
					{
						Console.WriteLine();
						Console.WriteLine(e.Message);
					}
					
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftEngChat;
using System;
using System.Collections.Generic;

namespace UnitTestJsonParser
{
    [TestClass]
    public class UnitTest1
    {
        private DatabaseManegement dataBase = new DatabaseManegement();
        private static readonly string fileName = "DB.txt";
        private static string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName;
        private List<User> userList = new List<User>();
        private ServerCrypto crypto = new ServerCrypto();


        [TestMethod]
        public void ReadFromFile()
        {
            List<string> info = new List<string>
            {
                "Admin",
                "mail",
                "112",
                "Admin",
                "Adminson"
            };
            userList.Add(new User(info));

            // Assert.AreEqual(userList, dataBase.DBread(filePath));
            Assert.IsNotNull(dataBase.DBread(filePath));
        }

        [TestMethod]
        public void TestHashMethod()
        {
            
            string test = "Anders Olsson";
            string hash1 = crypto.Sha256_hash(test);
            string hash2 = crypto.Sha256_hash(test);

            Assert.AreEqual(hash1, hash2);

           

     

        }
    }
}

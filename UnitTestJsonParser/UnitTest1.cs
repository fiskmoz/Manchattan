using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftEngChat;
using System.Collections.Generic;

namespace UnitTestJsonParser
{
    [TestClass]
    public class UnitTest1
    {
        private DatabaseManegement dataBase = new DatabaseManegement();
        private List<User> userList = new List<User>();

        [TestMethod]
        public void readFromFile()
        {
            userList = dataBase.DBread("Siafjosjfjaojs");
            Assert.IsNotNull(userList);
        }
    }
}

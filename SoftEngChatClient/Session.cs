using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient
{
    class Session
    {
        private string sessionUser;
        private string userPassword;
        static string sessionSaveName = "SessionSave.txt";
        public string sessionSavePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + sessionSaveName;
        public string[] overwrite = { " " };
        FileManager saveToFile;
        public Session(string username, string password, bool saveUserToNextSession)
        {
            sessionUser = username;
            userPassword = password;
            saveToFile = new FileManager();

            string[] userInfo = { sessionUser, userPassword };

            if (checkRememberMe(saveUserToNextSession))
                printRememberMeToFile(userInfo);
            else
                printRememberMeToFile(overwrite);
        }
        
        private bool checkRememberMe(bool remember)
        {
            if (remember == true)
                return true;
            else
                return false;
                
        }
        private void printRememberMeToFile(string[] userInfo)
        {
            saveToFile.readToFile(sessionSavePath, userInfo);
        }
    }
}

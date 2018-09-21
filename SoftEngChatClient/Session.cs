using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient
{/*
    class Session
    {
        public int sessionID { get; set; }
        private string sessionUser;
        private string userPassword;
        private bool rememberMe;
        public Session(string username, string password, bool saveInfo, int sessionCounter)
        {
            sessionID = ++sessionCounter;
            sessionUser = username;
            userPassword = password;
            rememberMe = saveInfo;

            if(openNewSession(sessionID, sessionUser))
            {
                if(checkRememberMe(rememberMe))
                    printRememberMeToFile(sessionUser, userPassword);

                
                // Gör saker
            }
                //terminate instance of Class
            
            
        }
        public bool openNewSession(int SID, string user)
        {
            //return getSessionAck(SID, user);
            return true;
        }
        private bool checkRememberMe(bool remember)
        {
            if (remember == true)
                return true;
            else
                return false;
                
        }
        private void printRememberMeToFile(string user, string pass)
        {
            FileManager FM = new FileManager();
            string[] userInfo = { user, pass };
            FM.readToFile(userInfo);
        }
    }*/
}

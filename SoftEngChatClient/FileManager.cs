using SoftEngChatClient.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient
{
    class FileManager
    {
        public ClientCrypto cyptoMessage { get; set; }

       public FileManager()
        {
            cyptoMessage = new ClientCrypto();
            
        }



        //Reads and decrypt from file using the global key.
        public string ReadSessionFromFile(string filePath) 
        {
            string decryptadText = "";
            try
            {
                byte[] data = File.ReadAllBytes(filePath);
                decryptadText = cyptoMessage.DecryptWithGlobal(data);
            }
            catch(IOException e)
            {
                e.GetBaseException();
            }

            return decryptadText; 
        } 

        
        //Encrypt and write to file using the global key.
        public void WriteSessionToFile(string filePath, string[] readObject)
        {
            string text = "";
            byte[] encryptedString;

            foreach (var textFromParamater in readObject)
            {
                text += textFromParamater + ":";

            }
            encryptedString = cyptoMessage.EncryptWithGlobal(text);


            try
            {
                var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                fs.Write(encryptedString, 0, encryptedString.Length);
                fs.Close();
            }
            catch(IOException e)
            {
                e.GetBaseException();
            }
        }

        public void SaveIndividualChat()
        {

        }

        

		internal List<string> ReadContacts()
		{
			List<string> contactList = new List<string>();
			string contacts = ReadFromFile(ClientDriver.globalUsername + "/Contacts.txt");

			string[] contactArray = contacts.Split(':');

			foreach(string user in contactArray)
			{
				contactList.Add(user);
			}
			return contactList;
		}
	}
}

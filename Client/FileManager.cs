using Client.Controller;
using Client.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
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

        //Reads a file. Decrypts using personal key. Returns the file in plaintext.
        public string ReadFromFile(string filePath)
        {
            string decryptadText = "";
            try
            {
                byte[] data = File.ReadAllBytes(filePath);
                decryptadText = cyptoMessage.DecryptBytes(data);
            }
            catch (IOException e)
            {
                e.GetBaseException();
            }

            return decryptadText;
        }

        //Encryptws plaintext using the personal key and saves it to filePath.
        public void WriteToFile(string filePath, string plaintext)
        {
            byte[] encryptedString;
            
            encryptedString = cyptoMessage.EncryptString(plaintext);

            try
            {
                var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                fs.Write(encryptedString, 0, encryptedString.Length);
                fs.Close();
            }
            catch (IOException e)
            {
                e.GetBaseException();
            }
        }

        public void SaveIndividualChat(string username, string receiver, string messageLog)
        {
            WriteToFile(AppDomain.CurrentDomain.BaseDirectory + @"\" + username + @"\ChatLogs\" + receiver + ".txt", messageLog);

        }

        public string LoadIndividualChat(string username, string receiver)
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\" + username + @"\ChatLogs");
            string text = "";
            text = ReadFromFile(AppDomain.CurrentDomain.BaseDirectory + @"\" + username + @"\ChatLogs\" + receiver + ".txt");
            return text;
        }
        
        
		internal List<string> ReadContacts()
		{
			List<string> contactList = new List<string>();
			string contacts = ReadFromFile(ClientDriver.globalUsername + "/Contacts.txt");

			string[] contactArray = contacts.Split(':');

			foreach(string user in contactArray)
			{
                if(user != "") contactList.Add(user);
			}
			return contactList;
		}

        internal void ReadStatusMessages(List<Contact> contactList)
        {
            if(contactList.Count > 0 )
            {
                string statusMessages = ReadFromFile(ClientDriver.globalUsername + "/StatusMessages.txt");
                string[] statusArray = statusMessages.Split('§');
                int i = 0;
                foreach (var contact in contactList)
                {
                    contact.status = statusArray[i];
                    i++;
                }
            }

        }
		
		public byte[] CreatePackage(string path)
		{
			byte[] data = File.ReadAllBytes(path);

			byte[] dataLength = BitConverter.GetBytes(data.Length);
			byte[] package = new byte[4 + data.Length];
			dataLength.CopyTo(package, 0);
			data.CopyTo(package, 4);

			return package;
		}

		internal void SaveReceivedFile(byte[] file, string filename, string username)
		{
			Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\" + username + @"\Downloads\");
			File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"\" + username + @"\Downloads\" + filename, file);
		}

        public void SaveMyStatus(string username, string myStatus)
        {
            WriteToFile(AppDomain.CurrentDomain.BaseDirectory + @"\" + username + @"\MyStatus.txt", myStatus);
        }
        public string ReadMyStatus(string username)
        {
            return ReadFromFile(AppDomain.CurrentDomain.BaseDirectory + @"\" + username + @"\MyStatus.txt");
        }
	}
}

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
        private ClientCrypto cyptoMessage;

       public FileManager()
        {
            cyptoMessage = new ClientCrypto();

            //Random input for encryption 
            string input = "hejhejjkjdueoplikmnakduehgjdmnju";
            byte[] array = Encoding.ASCII.GetBytes(input);
            cyptoMessage.SetNewKey(array);
        }

        //Reads and decrypt from file.
        public string ReadFromFile(string filePath) 
        {
            string decryptadText = "";
            try
            {
                byte[] data = File.ReadAllBytes(filePath);
                decryptadText = cyptoMessage.DecryptBytes(data);
            }
            catch(IOException e)
            {
                e.GetBaseException();
            }

            return decryptadText; 
        } 

        
        //Encrypt and write to file.
        public void WriteToFile(string filePath, string[] readObject)
        {
            string text = "";
            byte[] encryptedString;

            foreach (var textFromParamater in readObject)
            {
                text += textFromParamater + ":";

            }
            encryptedString = cyptoMessage.EncryptString(text);


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

		internal List<string> ReadContacts()
		{
			throw new NotImplementedException();
		}
	}
}

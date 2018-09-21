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

        private LogCrypto cyptoMessage;
        private string text;

       public FileManager()
        {
            cyptoMessage = new LogCrypto();

            //Random input for encryption 
            string input = "hejhejjkjdueoplikmnakduehgjdmnju";
            byte[] array = Encoding.ASCII.GetBytes(input);
            cyptoMessage.SetNewKey(array);
        }


        
        //Encrypt and read to file.
        public void WriteToFile(string filePath, string[] readObject)
        {
            string text = "";
            byte[] encryptedString;

            foreach (var textFromParamater in readObject)
            {
                text += textFromParamater;
            }
            encryptedString = cyptoMessage.EncryptString(text);
        
            var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            fs.Write(encryptedString, 0, encryptedString.Length);
            fs.Close();

        }
    }
}

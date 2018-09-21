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


        public string ReadFromFile(string filePath) 
        {

            int size;
            byte[] data;
            int byteCounter;

            // Opens a stream to the path chosen in the open file dialog
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                size = (int)stream.Length; // Returns the length of the file
                data = new byte[size]; // Initializes and array in which to store the file
                stream.Read(data, 0, size); // Begins to read from the constructed stream

                byteCounter = 0;
                while (byteCounter < size)
                {
                    int i = data[byteCounter];

                    byteCounter++;
                 
                }
            }
                return cyptoMessage.DecryptBytes(data); 
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

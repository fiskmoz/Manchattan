using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient
{
    class ClientCrypto
    {
        private AesManaged aes;

        private string keyString = "hejhejjkjdueoplikmnakduehgjdmnju";
        private byte[] superKey;

        public ClientCrypto()
        {
            aes = new AesManaged();
            aes.GenerateKey();
            superKey = Encoding.ASCII.GetBytes(keyString);
        }

        public ClientCrypto(byte[] key)
        {
            aes = new AesManaged();
            aes.Key = key;
            
        }

        public void SetNewKey(byte[] key)
        {
            aes.Key = key;
        }

        public void GenerateNewKey()
        {
            aes.GenerateKey();
        }

        public byte[] EncryptWithGlobal(string chatLog)
        {
            byte[] key = aes.Key;
            aes.Key = superKey;

            byte[] returnValue = EncryptString(chatLog);

            aes.Key = key;
            return returnValue;
        }

        public string DecryptWithGlobal(byte[] cipher)
        {
            byte[] key = aes.Key;
            aes.Key = superKey;

            string returnValue = DecryptBytes(cipher);

            aes.Key = key;
            return returnValue;
        }

        public byte[] EncryptString(string chatLog)
        {
            aes.GenerateIV();
            byte[] cryptoIV = aes.IV;
            byte[] encryptedString;

            encryptedString = EncryptAES(chatLog, aes.Key, cryptoIV);

            byte[] cipher = new byte[cryptoIV.Length + encryptedString.Length];
            Buffer.BlockCopy(cryptoIV, 0, cipher, 0, cryptoIV.Length);
            Buffer.BlockCopy(encryptedString, 0, cipher, cryptoIV.Length, encryptedString.Length);
      
            return cipher;
        }

        public string DecryptBytes(byte[] cipher)
        {
            if (cipher.Length == 0) return "";
            byte[] cryptoIV = new byte[16];
            byte[] encryptedString = new byte[cipher.Length - 16];
            string decryptedString;

            Buffer.BlockCopy(cipher, 0, cryptoIV, 0, 16);
            Buffer.BlockCopy(cipher, 16, encryptedString, 0, encryptedString.Length);

            decryptedString = DecryptAES(encryptedString, aes.Key, cryptoIV);

            return decryptedString;
        }

        //Copied encryption function 
        static byte[] EncryptAES(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Padding = PaddingMode.PKCS7;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        //Copied decryption function
        static string DecryptAES(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Padding = PaddingMode.PKCS7;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

        //Method to hash a string
        public string Sha256_hash(string plaintext)
        {
            StringBuilder sb = new StringBuilder();
            using(SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(plaintext));

                foreach(Byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChat
{
    public class ServerCrypto
    {
        //Generates AES key.
        public byte[] GenerateAesKey()
        {
            AesManaged aes = new AesManaged();
            aes.GenerateKey();
            return aes.Key;
        }


        //Hashes a string with SHA256.
        public string Sha256_hash(string plaintext)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(plaintext));

                foreach (Byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }
}

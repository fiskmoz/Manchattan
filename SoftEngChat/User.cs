using System;
using System.Security.Cryptography;
using System.Text;

public class User
{
    private static int IDnr;
    public int ID { get;  private set; }
    public string name { get; set; }
    public string password { get; set; }
    public string mail { get; set; }
    public string key { get; set; }
    

    public User(string name, string mail, string Pass)
    {
        this.ID = ++IDnr;
        this.name = name;
        this.mail = mail;
        this.password = Pass;

        GenerateKey();
    }

    //Set key by byte array
    public void SetKey(byte[] byteArrayKey)
    {
        this.key = Encoding.UTF8.GetString(byteArrayKey);
    }

    //Get key as byte array
    public byte[] GetBytesKey()
    {
        return Encoding.UTF8.GetBytes(key);
    }

    public void GenerateKey()
    {
        AesManaged aes = new AesManaged();
        aes.GenerateKey();
        SetKey(aes.Key);
    }
}

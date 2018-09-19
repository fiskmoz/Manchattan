using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public class User
{



    private static int IDnr;
    public int ID { get;  set; }
    public string UserName { get; set; }
    public string mail { get; set; }
	public string password { get; set; }
	public string Firstname { get; set;}
    public string LastName { get; set; }
	public string key { get; set; }

	public User(int id, string username, string mail, string password, string firstName, string lastName, string key)
	{
		this.ID			= id;
		this.UserName	= username;
		this.mail		= mail;
		this.password	= password;
		this.Firstname	= firstName;
		this.LastName	= lastName;
		this.key		= key;
	}

	public User(List<string> userInfo)
    {
        this.ID = ++IDnr;
        this.UserName	=	userInfo[0];
		this.mail		=	userInfo[1];
		this.password	=	userInfo[2];
		this.Firstname	=	userInfo[3];
		this.LastName	=	userInfo[4];

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

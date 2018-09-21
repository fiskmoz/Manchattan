using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public class User
{
    private static int IDnr;
    public int ID { get;  set; }
    public string UserName { get; set; }
    public string Mail { get; set; }
	public string Password { get; set; }
	public string Firstname { get; set;}
    public string LastName { get; set; }

    public User(List<string> userInfo)
    {
        this.ID = ++IDnr;
        this.UserName = userInfo[0];
        this.Mail = userInfo[1];
        this.Password = userInfo[2];
        this.Firstname = userInfo[3];
        this.LastName = userInfo[4];
    }

    [JsonConstructor]
    public User(int id, string username, string mail, string password, string firstName, string lastName)
	{
		this.ID			= id;
		this.UserName	= username;
		this.Mail		= mail;
		this.Password	= password;
		this.Firstname	= firstName;
		this.LastName	= lastName;
	}
}

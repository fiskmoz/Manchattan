using System;

public class User
{
    private static int IDnr;
    public int ID { get;  private set; }
    public string name { get; set; }
    public string password { get; set; }
    public string mail { get; set; }
    

    public User(string name, string mail, string Pass)
    {
        this.ID = ++IDnr;
        this.name = name;
        this.mail = mail;
        this.password = Pass;
    }
}

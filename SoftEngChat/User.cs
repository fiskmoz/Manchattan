using System;

public class User
{



    public int ID { get; set; }
    public string name { get; set; }
    public string password { get; set; }
    public string mail { get; set; }
    

    public User(string name, string mail, string Pass)
    {
        this.ID++;
        this.name = name;
        this.mail = mail;
        this.password = Pass;
    }
}

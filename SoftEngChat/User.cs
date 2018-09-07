using System;

public class User
{


    public struct user
    {
        int ID;
        String name;
        String password;
        String mail;
    }

    public User() { ID++; }





// Get and set function for user.
    public int ID { get;  set; }
    public String name { get; set; }
    public String password { get; set; }
    public String mail { get; set; }


}

using Newtonsoft.Json;
using System.Collections.Generic;

public class User
{
    private static int IDnr;
    public int ID { get;  set; }
    public string userName { get; set; }
    public string mail { get; set; }
	public string password { get; set; }
	private string firstName { get; set;}
    private string lastName { get; set; }

    //Standard constructor.
    public User(List<string> userInfo)
    {

        ID         = ++IDnr;
        userName   = userInfo[0];
        mail       = userInfo[1];
        password   = userInfo[2];
        firstName  = userInfo[3];
        lastName   = userInfo[4];
    }

    //Constructor when parsing in JSON.
    [JsonConstructor]
    public User(int ID, string userName, string mail, string password, string firstName, string lastName)
	{
		this.ID			= ID;
		this.userName	= userName;
		this.mail		= mail;
		this.password	= password;
		this.firstName	= firstName;
		this.lastName	= lastName;
	}
}

namespace BlazorWASM.Model;
public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public int SecurityLevel { get; set; }
    public string Domain { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    /*
    // I Troels opgave er dette ikke med.
    public string Name { get;  set; }

    public string Password { get;  set; }

    public string Role { get;  set; }

    public int SecurityLevel { get;  set; }
    public int BirthYear { get;  set; }

    public string Domain { get; set; }
     */
    
    //Den er ikke med i troels opgave
    /*public User(string username, string password, string role, string email, int securityLevel, string domain, string name, int age)
    {
        Username = username;
        Password = password;
        Role = role;
        Email = email;
        SecurityLevel = securityLevel;
        Domain = domain;
        Name = name;
        Age = age;
    }*/
}
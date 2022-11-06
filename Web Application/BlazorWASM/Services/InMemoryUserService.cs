using Blazor_Login.Model;

namespace Blazor_Login.Services;

public class InMemoryUserService
{
    public async Task<User?> GetUserAsync(string username)
    {
        User? find = users.Find(user => user.Name.Equals(username));
        return find;
    }

    private List<User> users = new()
    {
        new User("Troels", "Troels1234", "Teacher", "ds@34.dk", 1986,"lære","Troels",23),
        new User("Maria", "oneTwo3FOUR", "Student", "ds@37.dk", 2001,"DL","Nina",22),
        new User("Anne", "password", "HeadOfDepartment", "ds@74.dk", 1975,"FL","Anne",90)        
    };
}
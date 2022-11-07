using BlazorWASM.Model;

namespace BlazorWASM.Services.Impls;

public class InMemoryUserService : IUserService
{
    public Task<User?> GetUserAsync(string username)
    {
        User? find = users.Find(user => user.Name.Equals(username));
        return Task.FromResult(find);
    }

    private List<User> users = new()
    {
        new User
        {
            Username = "Troels", Password = "Troels1234", Role = "Teacher", Email = "ds@34.dk", SecurityLevel = 5, Domain = "via", Name ="Troels", Age = 23
        },
        new User { Username = "Maria", Password = "oneTwo3FOUR", Role = "Student", Email = "ds@37.dk", SecurityLevel = 1, Domain = "via", Name = "Nina", Age = 22 },
        new User { Username = "Anne", Password = "password", Role = "HeadOfDepartment", Email = "ds@74.dk", SecurityLevel = 5, Domain = "google", Name = "Anne", Age = 90 }        
    };
}
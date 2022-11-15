using System.ComponentModel.DataAnnotations;
using FileData.DAOs;
using Shared.Models;

namespace WebApi.Services;

public class AuthService : IAuthService
{

    private readonly IList<User> userDaos = new List<User>
    {
        new User
        {
            Age = 36,
            Email = "test@via.dk",
            Domain = "via",
            Name = "Test",
            Password = "test1234",
            Role = "Teacher",
            UserName = "test",
            SecurityLevel = 4
        },
        new User
        {
            Age = 34,
            Email = "jakob@gmail.com",
            Domain = "gmail",
            Name = "Jakob Rasmussen",
            Password = "password",
            Role = "Student",
            UserName = "jknr",
            SecurityLevel = 2
        }
    };

    public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = userDaos.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }


    public Task RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list
        
        userDaos.Add(user);
        
        return Task.CompletedTask;
    }
    
}
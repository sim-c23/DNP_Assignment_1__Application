using Blazor_Login.Model;

namespace Blazor_Login.Services;

public interface IUserService
{
    public Task<User> GetUserAsync(string username);
    
}
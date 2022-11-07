using BlazorWASM.Model;

namespace BlazorWASM.Services;

public interface IUserService
{
    public Task<User> GetUserAsync(string username);
    
}
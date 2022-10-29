using Shared.DTOs;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);
    Task<User?> GetByIdAsync(int id);

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
    
    
}
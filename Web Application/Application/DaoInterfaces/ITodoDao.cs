using Shared.DTOs;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface ITodoDao

// The method takes a Todo and returns a Todo (because the Id is set)
{
    Task<Todo> CreateAsync(Todo todo);
    public Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchParams);
}
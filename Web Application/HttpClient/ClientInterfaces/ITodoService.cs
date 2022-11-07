using Shared.DTOs;
using Shared.Models;

namespace HttpClient.ClientInterfaces;

public interface ITodoService
{
    Task CreateAsync(TodoCreationDto dto);

    Task<ICollection<Todo>> GetAsync(string? userName, int? userId, bool? completedStatus, string? titleContains);
    Task UpdateAsync(TodoUpdateDto dto);
    Task<TodoBasicDto> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}
        

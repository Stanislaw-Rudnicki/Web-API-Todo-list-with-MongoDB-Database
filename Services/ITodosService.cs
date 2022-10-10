using WebApplication7_MongoDB.Models;

namespace WebApplication7_MongoDB.Services;

public interface ITodosService
{
    Task<List<TodoDTO>> GetAsync();
    Task<List<TodoDTO>> GetAsync(int pageSize, int page);
    Task<TodoDTO> GetAsync(string id);
    Task<TodoDTO> CreateAsync(TodoDTO todo);
    Task UpdateAsync(string id, TodoDTO todo);
    Task MarkAsComlpetedAsync(string id);
}

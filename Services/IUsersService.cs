using WebApplication7_MongoDB.Models;

namespace WebApplication7_MongoDB.Services;

public interface IUsersService
{
    Task<List<UserDTO>> GetAsync();
    Task<UserDTO> CreateAsync(UserDTO todo);
}

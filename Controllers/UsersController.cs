using Microsoft.AspNetCore.Mvc;
using WebApplication7_MongoDB.Services;
using WebApplication7_MongoDB.Models;

namespace WebApplication7_MongoDB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UsersService _usersService;

    public UsersController(UsersService mongoDBService)
    {
        _usersService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<UserDTO>> Get()
    {
        return await _usersService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserDTO user)
    {
        await _usersService.CreateAsync(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }
}

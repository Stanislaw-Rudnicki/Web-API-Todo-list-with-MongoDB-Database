using Microsoft.AspNetCore.Mvc;
using WebApplication7_MongoDB.Services;
using WebApplication7_MongoDB.Models;

namespace WebApplication7_MongoDB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly TodosService _todosService;

    public TodosController(TodosService mongoDBService)
    {
        _todosService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<TodoDTO>> Get()
    {
        return await _todosService.GetAsync();
    }

    [HttpGet("{pageSize}/{page}")]
    public async Task<List<TodoDTO>> Get(int pageSize, int page)
    {
        return await _todosService.GetAsync(pageSize, page);
    }

    [HttpGet("{id}")]
    public async Task<TodoDTO> Get(string id)
    {
        return await _todosService.GetAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TodoDTO todo)
    {
        await _todosService.CreateAsync(todo);
        return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] TodoDTO todo)
    {
        await _todosService.UpdateAsync(id, todo);
        return NoContent();
    }

    [HttpPut("MarkAsComlpeted/{id}")]
    public async Task<IActionResult> MarkAsComlpeted(string id)
    {
        await _todosService.MarkAsComlpetedAsync(id);
        return NoContent();
    }
}

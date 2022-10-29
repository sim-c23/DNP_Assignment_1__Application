using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace WebAPI.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("[controller]")]

public class TodoController : ControllerBase
{
    private readonly ITodoLogic TodoLogic;

    public TodoController(ITodoLogic todoLogic)
    {
        TodoLogic = todoLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Todo>> CreateAsync([FromBody]TodoCreationDto dto)
    {
        try
        {
            Todo created = await TodoLogic.CreateAsync(dto);
            return Created($"/todos/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetAsync([FromQuery] string? userName, [FromQuery] int? userId,
        [FromQuery] bool? completedStatus, [FromQuery] string? titleContains)
    {
        try
        {
            SearchTodoParametersDto parameters = new(userName, userId, completedStatus, titleContains);
            var todos = await TodoLogic.GetAsync(parameters);
            return Ok(todos);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}
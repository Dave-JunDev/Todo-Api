
using DTO;
using FluentValidation;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace Controllers;

[Route("[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;
    private readonly IValidator<TodoDTO> _todoValidator;
    private readonly IPaginationUtil _paginationUtil;
    private readonly ILogger _logger;
    public TodoController(
        ITodoService todoService, 
        IValidator<TodoDTO> todoValidator, 
        IPaginationUtil paginationUtil,
        ILogger<TodoController> logger
        )
    {
        _todoService = todoService;
        _todoValidator = todoValidator;
        _paginationUtil = paginationUtil;
        _logger = logger;
    }
   
    [HttpGet]
    public async Task<IActionResult> GetTodos([FromQuery] int page = 1, [FromQuery] int recordsPerPage = 10)
    {
        List<TodoDTO>? todos = await _todoService.GetTodos();
        _logger.LogInformation("GetTodos");
        if (todos.Count == 0)
            return NotFound("No have records");
        
        var pagination = _paginationUtil.GetPagination(todos, page, recordsPerPage);
        _logger.LogInformation("Pagination created");
        return Ok(pagination);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoById(int id)
    {
        TodoDTO? todo = await _todoService.GetTodoById(id);
        if (todo.Id == 0)
            return NotFound();

        return Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodo(TodoDTO todo)
    {
        var validationResult = await _todoValidator.ValidateAsync(todo);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        todo = await _todoService.CreateTodo(todo);
        return Ok(todo);
    }

    [HttpPost("many")]
    public async Task<IActionResult> CreateManyTodos(List<TodoDTO> todos)
    {
        todos = await _todoService.CreateManyTodos(todos);
        return Ok(todos);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodoById(int id, TodoDTO todo)
    {
        TodoDTO? todoDTO = await _todoService.UpdateTodoById(id, todo);
        if (todoDTO.Id == 0)
            return NotFound();

        return Ok(todoDTO);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoById(int id)
    {
        bool result = await _todoService.DeleteTodoById(id);
        
        if (result == false)
            return NotFound();

        return Ok();
    }
}
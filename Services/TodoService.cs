using Context;
using DTO;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class TodoService : ITodoService
{
    private readonly PostgresContext _context;
    public TodoService(PostgresContext context)
    {
        _context = context;
    }

    public async Task<List<TodoDTO>> GetTodos()
    {
        List<TodoDTO>? todos = await _context.Todos.AsQueryable().ToListAsync();
        
        if (todos == null)
            return [];

        return todos;
    }

    public async Task<TodoDTO> GetTodoById(int id)
    {
        TodoDTO? todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
        if (todo == null)
            return new();

        return todo;
    }

    public async Task<TodoDTO> CreateTodo(TodoDTO todo)
    {
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
        
        return todo;
    }

    public async Task<List<TodoDTO>> CreateManyTodos(List<TodoDTO> todos)
    {
        await _context.Todos.AddRangeAsync(todos);
        await _context.SaveChangesAsync();
        
        return todos;
    }

    public async Task<TodoDTO> UpdateTodoById(int id, TodoDTO todo)
    {
        TodoDTO? todoToUpdate = await GetTodoById(id);
        if (todoToUpdate.Id == 0)
            return todoToUpdate;

        todoToUpdate.Title = todo.Title;
        todoToUpdate.Description = todo.Description;
        todoToUpdate.IsCompleted = todo.IsCompleted;

        _context.Todos.Update(todoToUpdate);
        _context.SaveChanges();

        return todoToUpdate;
    }

    public async Task<bool> DeleteTodoById(int id)
    {
        TodoDTO? todo = await GetTodoById(id);

        if (todo.Id == 0)
            return false;

        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
        return true;
    }
}
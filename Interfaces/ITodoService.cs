using DTO;

namespace Interfaces;

public interface ITodoService
{
    Task<List<TodoDTO>> GetTodos();
    Task<TodoDTO> GetTodoById(int id);
    Task<List<TodoDTO>> CreateManyTodos(List<TodoDTO> todos);
    Task<TodoDTO> CreateTodo(TodoDTO todo);
    Task<TodoDTO> UpdateTodoById(int id, TodoDTO todo);
    Task<bool> DeleteTodoById(int id);
}
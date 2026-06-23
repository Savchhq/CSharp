using TodoApp.Core.Models;

namespace TodoApp.Core.Interfaces;

public interface ITaskRepository
{
    Task<(IEnumerable<TodoTask> Items, int TotalCount)> GetAllAsync(
        int userId, 
        string? searchQuery = null, 
        int? categoryId = null, 
        int pageNumber = 1, 
        int pageSize = 10);
        
    Task<TodoTask?> GetByIdAsync(int id, int userId);
    
    Task<TodoTask> CreateAsync(TodoTask todoTask);
    Task<TodoTask?> UpdateAsync(int id, TodoTask todoTask, int userId);
    Task<TodoTask?> DeleteAsync(int id, int userId);
}
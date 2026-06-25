using TodoApp.BLL.DTOs;

namespace TodoApp.BLL.Interfaces;

public interface ITaskService
{
    Task<(IEnumerable<TaskDto> Items, int TotalCount)> GetAllAsync(int userId, string? searchQuery = null, int? categoryId = null, int pageNumber = 1, int pageSize = 10);
    
    Task<TaskDto?> GetByIdAsync(int id, int userId);
    
    Task<TaskDto> CreateAsync(CreateTaskDto taskDto, int userId);
    
    Task<TaskDto?> UpdateAsync(int id, UpdateTaskDto taskDto, int userId);
    
    Task<TaskDto?> DeleteAsync(int id, int userId);
}
using AutoMapper;
using TodoApp.BLL.DTOs;
using TodoApp.BLL.Interfaces;
using TodoApp.Core.Interfaces;
using TodoApp.Core.Models;

namespace TodoApp.BLL.Services;

public class TaskService : ITaskService
{
    private readonly IMapper mapper;
    private readonly ITaskRepository taskRepository;
    public TaskService(IMapper mapper, ITaskRepository taskRepository)
    {
        this.mapper = mapper;
        this.taskRepository = taskRepository;
    }
    public async Task<(IEnumerable<TaskDto> Items, int TotalCount)> GetAllAsync(int userId, string? searchQuery = null, int? categoryId = null, int pageNumber = 1, int pageSize = 10)
    {
        var tasks = await  taskRepository.GetAllAsync(userId, searchQuery, categoryId, pageNumber, pageSize);
        var dtos = mapper.Map<IEnumerable<TaskDto>>(tasks.Items);
        return (dtos, tasks.TotalCount);
    }
    public async Task<TaskDto?> GetByIdAsync(int id, int userId)
    {
        var task = await taskRepository.GetByIdAsync(id, userId);
        if(task == null)
        return null;
        return mapper.Map<TaskDto>(task);
    }
    public async Task<TaskDto> CreateAsync(TaskDto taskDto, int userId)
    {
        var task = mapper.Map<TodoTask>(taskDto);
        task.UserId = userId;
        task = await taskRepository.CreateAsync(task);
        return mapper.Map<TaskDto>(task);
    }
    public async Task<TaskDto?> UpdateAsync(int id, TaskDto taskDto, int userId)
    {
        var task = mapper.Map<TodoTask>(taskDto);

        var updatedTask = await taskRepository.UpdateAsync(id, task, userId);

        if (updatedTask == null)
        return null;

        return mapper.Map<TaskDto>(updatedTask);
    }
    public async Task<TaskDto?> DeleteAsync(int id, int userId)
    {
    var deletedTask = await taskRepository.DeleteAsync(id, userId);

    if (deletedTask == null)
        return null;

    return mapper.Map<TaskDto>(deletedTask);
    }
}
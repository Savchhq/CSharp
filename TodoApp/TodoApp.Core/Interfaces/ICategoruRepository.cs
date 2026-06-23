using TodoApp.Core.Models;

namespace TodoApp.Core.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllByUserIdAsync(int userId);
    Task<Category?> GetByIdAsync(int id, int userId);
    Task<Category> CreateAsync(Category category);
    Task<Category?> UpdateAsync(int id, Category category, int userId);
    Task<Category?> DeleteAsync(int id, int userId);
}
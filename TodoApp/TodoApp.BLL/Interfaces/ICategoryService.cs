using TodoApp.BLL.DTOs;


namespace TodoApp.BLL.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllByUserIdAsync(int userId);
    Task<CategoryDto?> GetByIdAsync(int id, int userId);
    Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto categoryDto, int userId);
    Task<CategoryDto?> UpdateAsync(int id, CreateUpdateCategoryDto categoryDto, int userId);
    Task<CategoryDto?> DeleteAsync(int id, int userId);
}
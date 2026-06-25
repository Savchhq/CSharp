using AutoMapper;
using TodoApp.BLL.DTOs;
using TodoApp.BLL.Interfaces;
using TodoApp.Core.Interfaces;
using TodoApp.Core.Models;

namespace TodoApp.BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllByUserIdAsync(int userId)
    {
        var categories = await _categoryRepository.GetAllByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto?> GetByIdAsync(int id, int userId)
    {
        var category = await _categoryRepository.GetByIdAsync(id, userId);
        if (category == null) 
        return null;
        
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> CreateAsync(CategoryDto categoryDto, int userId)
    {
        var category = _mapper.Map<Category>(categoryDto);
        category.UserId = userId; 
        var createdCategory = await _categoryRepository.CreateAsync(category);

        return _mapper.Map<CategoryDto>(createdCategory);
    }

    public async Task<CategoryDto?> UpdateAsync(int id, CategoryDto categoryDto, int userId)
    {
        var category = _mapper.Map<Category>(categoryDto);
        var updatedCategory = await _categoryRepository.UpdateAsync(id, category, userId);
        if (updatedCategory == null)
        return null;

        return _mapper.Map<CategoryDto>(updatedCategory);
    }

    public async Task<CategoryDto?> DeleteAsync(int id, int userId)
    {
        var deletedCategory = await _categoryRepository.DeleteAsync(id, userId);
        if (deletedCategory == null) return null;

        return _mapper.Map<CategoryDto>(deletedCategory);
    }
}
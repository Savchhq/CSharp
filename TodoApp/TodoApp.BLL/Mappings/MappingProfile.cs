using AutoMapper;
using TodoApp.Core.Models;
using TodoApp.BLL.DTOs;

namespace TodoApp.BLL.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TodoTask, TaskDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
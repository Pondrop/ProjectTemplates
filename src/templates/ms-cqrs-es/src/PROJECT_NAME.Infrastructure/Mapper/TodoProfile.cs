using AutoMapper;
using PROJECT_NAME.Application.Commands;
using PROJECT_NAME.Domain.Models;
using PROJECT_NAME.Infrastructure.Models;

namespace PROJECT_NAME.Infrastructure.Mapper;

public class ExampleProfile : Profile
{
    public ExampleProfile()
    {
        CreateMap<TodoItemEntity, TodoItem>().ReverseMap();
        CreateMap<TodoItemEntity, CreateTodoCommand>().ReverseMap();
    }
}

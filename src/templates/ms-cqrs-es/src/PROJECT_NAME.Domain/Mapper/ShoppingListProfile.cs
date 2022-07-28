using AutoMapper;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Domain.Mapper;

public class ShoppingListProfile : Profile
{
    public ShoppingListProfile()
    {
        CreateMap<ShoppingListItemEntity, ShoppingListItemRecord>().ReverseMap();
        CreateMap<ShoppingListEntity, ShoppingListRecord>().ReverseMap();
    }
}

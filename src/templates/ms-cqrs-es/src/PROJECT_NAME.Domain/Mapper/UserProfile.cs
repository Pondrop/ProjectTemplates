using AutoMapper;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Domain.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserEntity, UserRecord>().ReverseMap();
    }
}

using AgendaApi.Model.User;
using AutoMapper;

namespace AgendaApi.Mapper
{
    public class ApplicationMappings : Profile
    {
        public ApplicationMappings()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}
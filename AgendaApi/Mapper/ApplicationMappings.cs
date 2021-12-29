using AgendaApi.Model.Patient;
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
            
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Patient, PatientCreateDto>().ReverseMap();
            CreateMap<Patient, PatientUpdateDto>().ReverseMap();
        }
    }
}
using AgendaApi.Domain.Consultation.Models;
using AgendaApi.Domain.Patient.Models;
using AgendaApi.Domain.User.Models;
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

            CreateMap<Consultation, ConsultationDto>().ReverseMap();
            CreateMap<Consultation, ConsultationCreateDto>().ReverseMap();
            CreateMap<Consultation, ConsultationUpdateDto>().ReverseMap();
        }
    }
}
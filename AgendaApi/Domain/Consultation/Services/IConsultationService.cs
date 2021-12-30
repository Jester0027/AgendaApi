using System.Collections.Generic;
using AgendaApi.Domain.Consultation.Models;
using AgendaApi.Models.Page;

namespace AgendaApi.Domain.Consultation.Services
{
    public interface IConsultationService
    {
        Page<ConsultationDto> GetPage(int page, int limit);
        List<ConsultationDto> GetAll();
        ConsultationDto GetById(int id);
        Models.Consultation Create(ConsultationCreateDto consultationCreateDto);
        bool Update(ConsultationUpdateDto consultationUpdateDto);
        bool Delete(Models.Consultation consultation);
        bool Delete(int id);
    }
}
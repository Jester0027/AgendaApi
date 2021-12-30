using System.Collections.Generic;
using AgendaApi.Model.Consultation;
using AgendaApi.Model.Page;

namespace AgendaApi.Services.Consultation
{
    public interface IConsultationService
    {
        Page<ConsultationDto> GetPage(int page, int limit);
        List<ConsultationDto> GetAll();
        ConsultationDto GetById(int id);
        Model.Consultation.Consultation Create(ConsultationCreateDto consultationCreateDto);
        bool Update(ConsultationUpdateDto consultationUpdateDto);
        bool Delete(Model.Consultation.Consultation consultation);
        bool Delete(int id);
    }
}
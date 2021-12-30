using System.Collections.Generic;

namespace AgendaApi.Repositories.Consultation
{
    public interface IConsultationRepository
    {
        List<Model.Consultation.Consultation> GetPage(int page, int limit);
        List<Model.Consultation.Consultation> FindAll();
        Model.Consultation.Consultation GetById(int id);
        Model.Consultation.Consultation Add(Model.Consultation.Consultation consultation);
        bool Update(Model.Consultation.Consultation consultation);
        bool Delete(int id);
        bool Delete(Model.Consultation.Consultation consultation);
        bool Save();
        int Count();
    }
}
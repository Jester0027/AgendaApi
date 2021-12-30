using System.Collections.Generic;

namespace AgendaApi.Domain.Consultation.Repositories
{
    public interface IConsultationRepository
    {
        List<Models.Consultation> GetPage(int page, int limit);
        List<Models.Consultation> FindAll();
        Models.Consultation GetById(int id);
        Models.Consultation Add(Models.Consultation consultation);
        bool Update(Models.Consultation consultation);
        bool Delete(int id);
        bool Delete(Models.Consultation consultation);
        bool Save();
        int Count();
    }
}
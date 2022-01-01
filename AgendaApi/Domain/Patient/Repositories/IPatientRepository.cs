using System.Collections.Generic;

namespace AgendaApi.Domain.Patient.Repositories
{
    public interface IPatientRepository
    {
        List<Models.Patient> GetPage(int page, int limit);
        List<Models.Patient> FindAll();
        Models.Patient GetById(int id);
        Models.Patient Add(Models.Patient patient);
        bool Update(Models.Patient patient);
        bool Delete(int id);
        bool Delete(Models.Patient patient);
        bool Save();
        int Count();
    }
}
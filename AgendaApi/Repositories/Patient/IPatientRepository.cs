using System.Collections.Generic;

namespace AgendaApi.Repositories.Patient
{
    public interface IPatientRepository
    {
        List<Model.Patient.Patient> GetPage(int page, int limit);
        List<Model.Patient.Patient> FindAll();
        Model.Patient.Patient GetById(int id);
        Model.Patient.Patient Add(Model.Patient.Patient patient);
        bool Update(Model.Patient.Patient patient);
        bool Delete(int id);
        bool Delete(Model.Patient.Patient patient);
        bool Save();
        int Count();
    }
}
using System.Collections.Generic;
using System.Linq;
using AgendaApi.Data;

namespace AgendaApi.Repositories.Patient
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _db;

        public PatientRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public List<Model.Patient.Patient> GetPage(int page, int limit)
        {
            var patients = _db.Patients.Skip(page * limit - limit).Take(limit).ToList();
            return patients;
        }

        public List<Model.Patient.Patient> FindAll()
        {
            var patients = _db.Patients.ToList();
            return patients;
        }

        public Model.Patient.Patient GetById(int id)
        {
            var patient = _db.Patients.SingleOrDefault(p => p.Id == id);
            return patient;
        }

        public Model.Patient.Patient Add(Model.Patient.Patient patient)
        {
            var saved = _db.Patients.Add(patient);
            Save();
            return saved.Entity;
        }

        public bool Update(Model.Patient.Patient patient)
        {
            _db.Patients.Update(patient);
            return Save();
        }

        public bool Delete(int id)
        {
            return Delete(GetById(id));
        }

        public bool Delete(Model.Patient.Patient patient)
        {
            _db.Patients.Remove(patient);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }

        public int Count()
        {
            return _db.Patients.Count();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using AgendaApi.Data;

namespace AgendaApi.Domain.Patient.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _db;

        public PatientRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public List<Domain.Patient.Models.Patient> GetPage(int page, int limit)
        {
            var patients = _db.Patients.Skip(page * limit - limit).Take(limit).ToList();
            return patients;
        }

        public List<Domain.Patient.Models.Patient> FindAll()
        {
            var patients = _db.Patients.ToList();
            return patients;
        }

        public Domain.Patient.Models.Patient GetById(int id)
        {
            var patient = _db.Patients.SingleOrDefault(p => p.Id == id);
            return patient;
        }

        public Domain.Patient.Models.Patient Add(Domain.Patient.Models.Patient patient)
        {
            var saved = _db.Patients.Add(patient);
            Save();
            return saved.Entity;
        }

        public bool Update(Domain.Patient.Models.Patient patient)
        {
            _db.Patients.Update(patient);
            return Save();
        }

        public bool Delete(int id)
        {
            return Delete(GetById(id));
        }

        public bool Delete(Domain.Patient.Models.Patient patient)
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
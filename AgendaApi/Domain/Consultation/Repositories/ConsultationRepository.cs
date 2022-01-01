using System.Collections.Generic;
using System.Linq;
using AgendaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Domain.Consultation.Repositories
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly ApplicationDbContext _db;

        public ConsultationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Models.Consultation> GetPage(int page, int limit)
        {
            return _db.Consultations
                .Include(c => c.Doctor)
                .Include(c => c.Patient)
                .Skip(page * limit - limit)
                .Take(limit)
                .ToList();
        }

        public List<Models.Consultation> FindAll()
        {
            return _db.Consultations
                .Include(c => c.Doctor)
                .Include(c => c.Patient)
                .ToList();
        }

        public Models.Consultation GetById(int id)
        {
            return _db.Consultations
                .Include(c => c.Doctor)
                .Include(c => c.Patient)
                .SingleOrDefault(c => c.Id == id);
        }

        public Models.Consultation Add(Models.Consultation consultation)
        {
            var result = _db.Consultations.Add(consultation).Entity;
            Save();
            return result;
        }

        public bool Update(Models.Consultation consultation)
        {
            _db.Consultations.Update(consultation);
            return Save();
        }

        public bool Delete(int id)
        {
            return Delete(GetById(id));
        }

        public bool Delete(Models.Consultation consultation)
        {
            _db.Remove(consultation);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }

        public int Count()
        {
            return _db.Consultations.Count();
        }
    }
}
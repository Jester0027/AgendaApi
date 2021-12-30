using System.Collections.Generic;
using System.Linq;
using AgendaApi.Data;

namespace AgendaApi.Repositories.Consultation
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly ApplicationDbContext _db;

        public ConsultationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Model.Consultation.Consultation> GetPage(int page, int limit)
        {
            return _db.Consultations.Skip(page * limit - limit).Take(limit).ToList();
        }

        public List<Model.Consultation.Consultation> FindAll()
        {
            return _db.Consultations.ToList();
        }

        public Model.Consultation.Consultation GetById(int id)
        {
            return _db.Consultations.SingleOrDefault(c => c.Id == id);
        }

        public Model.Consultation.Consultation Add(Model.Consultation.Consultation consultation)
        {
            var result = _db.Consultations.Add(consultation).Entity;
            Save();
            return result;
        }

        public bool Update(Model.Consultation.Consultation consultation)
        {
            _db.Consultations.Update(consultation);
            return Save();
        }

        public bool Delete(int id)
        {
            return Delete(GetById(id));
        }

        public bool Delete(Model.Consultation.Consultation consultation)
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
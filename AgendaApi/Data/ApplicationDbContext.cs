using AgendaApi.Domain.Consultation.Models;
using AgendaApi.Domain.Patient.Models;
using AgendaApi.Domain.User.Models;
using AgendaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Consultation> Consultations { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
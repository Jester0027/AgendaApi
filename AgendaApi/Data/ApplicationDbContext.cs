using AgendaApi.Model;
using AgendaApi.Model.User;
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
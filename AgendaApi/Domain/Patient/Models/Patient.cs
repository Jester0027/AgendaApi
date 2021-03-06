using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Domain.Patient.Models
{
    public class Patient
    {
        [Key] public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
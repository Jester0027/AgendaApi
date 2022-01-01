using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Domain.User.Models
{
    public class User
    {
        [Key] public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
    }
}
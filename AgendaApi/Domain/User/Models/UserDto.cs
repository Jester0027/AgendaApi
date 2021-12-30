using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Domain.User.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }

    public class UserCreateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [RegularExpression("^Secretary|Doctor$", ErrorMessage = "The role should be either \"Secretary\" or \"Doctor\"")]
        public string Role { get; set; }
    }

    public class UserUpdateDto
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [RegularExpression("^Secretary|Doctor$", ErrorMessage = "The role should be either \"Secretary\" or \"Doctor\"")]
        public string Role { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using Toska.Models.Enums;

namespace Toska.DTOs.User
{
    public class CreateUserDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty; 



        [Required, MinLength(8)]
        public string Password { get; set; } = string.Empty; // plain here only for input — will be hashed



        [Required, MaxLength(100)]
        public string? FirstName { get; set; }



        [Required, MaxLength(100)]
        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }



        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
    }
}

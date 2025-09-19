using System.ComponentModel.DataAnnotations;
using Toska.Models.Enums;

namespace Toska.DTOs.User
{
    public class UserDto
    {
        public Guid PublicId { get; set; }


        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;   


        [Required, MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;


        [Required, MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        public DateTime? BirthDate { get; set; }

        public Gender Gender { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreateDate { get; set; }



        // Concurrency token
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}

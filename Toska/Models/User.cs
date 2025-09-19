using Toska.Models.Base;
using Toska.Models.Enums;

namespace Toska.Models
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; } // Use If Exposed in APIs
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; }




        //Navigation properties
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Session> Sessions { get; set; } = new List<Session>();

    }
}

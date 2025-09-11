using Toska.Models.Enums;

namespace Toska.Models
{
    public class User
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; } = Guid.NewGuid(); // Use If Exposed in APIs
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }



        //Navigation properties
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Session> Sessions { get; set; } = new List<Session>();

    }
}

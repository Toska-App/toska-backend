using Toska.Models.Base;

namespace Toska.Models.User
{
    public class Session : BaseEntity
    {
        public long Id { get; set; }
        public Guid PublicId { get; set; } // Use If Expose Active Sessions
        public int UserId { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime? LogoutDate { get; set; }


        // Navigation property
        public User User { get; set; }
    }
}

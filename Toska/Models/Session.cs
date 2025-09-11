namespace Toska.Models
{
    public class Session
    {
        public long Id { get; set; }
        public Guid PublicId { get; set; } = Guid.NewGuid(); // Use If Expose Active Sessions
        public int UserId { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime? LogoutDate { get; set; }


        // Navigation property
        public User User { get; set; }
    }
}

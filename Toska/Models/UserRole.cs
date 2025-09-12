namespace Toska.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime CreateDate { get; set; }


        // Navigation properties
        public User User { get; set; }
        public Role Role { get; set; }
    }
}

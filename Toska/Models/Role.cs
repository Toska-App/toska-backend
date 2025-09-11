namespace Toska.Models
{
    public class Role
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; } // Use If Expose Role Management via API
        public string Title { get; set; } 
        public string? Description { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }


        // Navigation properties
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}

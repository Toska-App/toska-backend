using Toska.Models.Base;

namespace Toska.Models.User
{
    public class Role : BaseEntity
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; } // Use If Expose Role Management via API
        public required string Title { get; set; } 
        public string? Description { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int CreatedBy { get; set; }



        // Navigation properties
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}

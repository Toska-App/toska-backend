using Toska.Models.Base;

namespace Toska.Models
{
    public class Permission : BaseEntity
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; } // Use If Expose Permissions to Admins
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string Key { get; set; }


        // Navigation property
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}

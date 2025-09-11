namespace Toska.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; } = Guid.NewGuid(); // Use If Expose Permissions to Admins
        public string Name { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }


        // Navigation property
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}

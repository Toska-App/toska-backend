using Toska.Models.Base;

namespace Toska.Models.User
{
    public class RolePermission : BaseEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }   


        // Navigation properties
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}

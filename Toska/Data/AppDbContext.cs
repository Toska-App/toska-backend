using Microsoft.EntityFrameworkCore;
using System.Text;
using Toska.Models.User;

namespace Toska.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        // DbSets for each entity
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Permission> Permissions { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;
        public DbSet<RolePermission> RolePermissions { get; set; } = null!;
        public DbSet<Session> Sessions { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            // This will automatically apply all IEntityTypeConfiguration<T>
            // Classes in the assembly (e.g. UserConfiguration, RoleConfiguration, etc.)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);



            // Global filter: automatically exclude deleted users
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
        }




    }
}

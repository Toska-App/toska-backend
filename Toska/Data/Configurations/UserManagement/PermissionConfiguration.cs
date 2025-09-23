using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toska.Models.User;

namespace Toska.Data.Configurations.UserManagement
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> b)
        {
            b.ToTable("Permissions");
            b.HasKey(p => p.Id);



            b.Property(p => p.PublicId)
                .HasDefaultValueSql("NEWSEQUENTIALID()")
                .ValueGeneratedOnAdd();



            b.Property(p => p.Name).IsRequired().HasMaxLength(200);
            b.Property(p => p.Description).HasMaxLength(500);
            b.Property(p => p.Key).IsRequired().HasMaxLength(150);



            b.HasIndex(p => p.Key)
                .IsUnique();



            b.HasMany(p => p.RolePermissions)
             .WithOne(rp => rp.Permission)
             .HasForeignKey(rp => rp.PermissionId)
             .OnDelete(DeleteBehavior.Restrict);



        }
    }
}

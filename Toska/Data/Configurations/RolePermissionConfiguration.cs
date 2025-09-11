using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toska.Models;

namespace Toska.Data.Configurations
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> b)
        {
            b.ToTable("RolePermissions");
            b.HasKey(rp => rp.Id);



            b.HasIndex(rp => new { rp.RoleId, rp.PermissionId }).IsUnique();



            b.Property(rp => rp.RoleId)
                .IsRequired();



            b.Property(rp => rp.PermissionId)
                .IsRequired();



            b.Property(rp => rp.CreateDate).HasDefaultValueSql("GETUTCDATE()");



            b.HasOne(rp => rp.Role)
             .WithMany(r => r.RolePermissions)
             .HasForeignKey(rp => rp.RoleId)
             .OnDelete(DeleteBehavior.Cascade); 



            b.HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toska.Models;

namespace Toska.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> b)
        {
            b.ToTable("Roles");
            b.HasKey(r => r.Id);



            b.Property(r => r.PublicId)
                .HasDefaultValueSql("NEWSEQUENTIALID()")
                .ValueGeneratedOnAdd();



            b.HasIndex(r => r.PublicId)
                .IsUnique();



            b.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(200);



            b.Property(r => r.Description)
                .HasMaxLength(500);



            b.Property(r => r.CreatedBy)
                .IsRequired();



            b.Property(r => r.CreateDate)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();



            b.Property(r => r.ModifyBy);
            b.Property(r => r.ModifyDate);



            b.HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Restrict);



            b.HasMany(r => r.RolePermissions)
                .WithOne(rp => rp.Role)
                .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}

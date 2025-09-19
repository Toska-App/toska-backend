using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toska.Models;

namespace Toska.Data.Configurations.UserManagement
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> b)
        {



            b.ToTable("Users");
            b.HasKey(u => u.Id);



            b.Property(u => u.PublicId)
                .HasDefaultValueSql("NEWSEQUENTIALID()")
                .ValueGeneratedOnAdd();



            b.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            b.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            b.Property(u => u.Email).IsRequired().HasMaxLength(256);
            b.HasIndex(u => u.Email).IsUnique().HasFilter("[IsDeleted] = 0");

            

            b.Property(u => u.PasswordHash).IsRequired().HasMaxLength(1024);
            b.Property(u => u.CreateDate).HasDefaultValueSql("GETUTCDATE()");
            b.Property(u => u.UpdateDate).IsRequired(false);


            b.Property(u => u.BirthDate)
                .HasColumnType("date") // stores only the year, month, and day (not time)
                .IsRequired(false);



            b.Property(u => u.Gender)
                .IsRequired();



            b.Property(u => u.IsActive)
             .HasDefaultValue(true);



            b.Property(u => u.IsDeleted)
                .HasDefaultValue(false);



            b.HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired(false)   // <-- make optional
                .OnDelete(DeleteBehavior.Cascade);



            b.HasMany(u => u.Sessions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                .IsRequired(false)   // <-- make optional
                .OnDelete(DeleteBehavior.Cascade);



            //Configure Concurrency Token in EF Core
            b.Property(u => u.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();




        }
    }
}

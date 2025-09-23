using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toska.Models.User;

namespace Toska.Data.Configurations.UserManagement
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> b)
        {



            b.ToTable("Sessions");
            b.HasKey(s => s.Id);



            b.Property(s => s.PublicId)
                .HasDefaultValueSql("NEWSEQUENTIALID()")
                .ValueGeneratedOnAdd();



            b.Property(s => s.LoginDate).HasDefaultValueSql("GETUTCDATE()");
            b.Property(s => s.LogoutDate).IsRequired(false);



            b.HasOne(s => s.User)
             .WithMany(u => u.Sessions)
             .HasForeignKey(s => s.UserId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

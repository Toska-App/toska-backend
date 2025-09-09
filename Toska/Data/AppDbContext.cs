using Microsoft.EntityFrameworkCore;
using Toska.Models;

namespace Toska.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;

    }
}

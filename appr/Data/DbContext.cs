using Microsoft.EntityFrameworkCore;
using appr.Models;

namespace appr.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Donation> Donations { get; set; }
    }
}

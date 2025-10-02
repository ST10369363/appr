using appr.Models;
using Microsoft.EntityFrameworkCore;

namespace appr.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Volunteer> Volunteers { get; set; } = null!;
        public DbSet<appr.Models.Task> Tasks { get; set; } = null!;
        public DbSet<Donation> Donations { get; set; } = null!;
        public DbSet<IncidentReport> IncidentReports { get; set; } = null!;
    }
}

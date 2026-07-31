using Microsoft.EntityFrameworkCore;

namespace CPTracker.Domain;

public class CPTrackerDbContext : DbContext
{
    public CPTrackerDbContext(DbContextOptions<CPTrackerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Problem> Problems { get; set; } = null!;
    public DbSet<Contest> Contests { get; set; } = null!;
    public DbSet<Submission> Submissions { get; set; } = null!;
}
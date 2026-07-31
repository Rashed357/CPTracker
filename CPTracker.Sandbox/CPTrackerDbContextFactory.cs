using CPTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CPTracker.Sandbox;

public class CPTrackerDbContextFactory : IDesignTimeDbContextFactory<CPTrackerDbContext>
{
    public CPTrackerDbContext CreateDbContext(string[] args)
    {
      var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddUserSecrets<CPTrackerDbContextFactory>()
        .Build();
  
        var connectionString = configuration.GetConnectionString("CPTrackerDb");

        var optionsBuilder = new DbContextOptionsBuilder<CPTrackerDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new CPTrackerDbContext(optionsBuilder.Options);
    }
}
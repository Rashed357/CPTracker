using CPTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

var connectionString = configuration.GetConnectionString("CPTrackerDb");

var optionsBuilder = new DbContextOptionsBuilder<CPTrackerDbContext>();
optionsBuilder.UseNpgsql(connectionString);

using var dbContext = new CPTrackerDbContext(optionsBuilder.Options);

var problem = new Problem
{
    Name = "Watermelon",
    PlatformProblemId = "4A",
    Rating = 800,
    Url = "https://codeforces.com/problemset/problem/4/A",
    SolvedAt = DateTime.SpecifyKind(new DateTime(2024, 3, 15), DateTimeKind.Utc)
};

dbContext.Problems.Add(problem);
dbContext.SaveChanges();

Console.WriteLine($"Saved problem with Id: {problem.Id}");
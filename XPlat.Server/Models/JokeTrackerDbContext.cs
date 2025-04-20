using Microsoft.EntityFrameworkCore;

namespace XPlat.Models;

public class JokeTrackerDbContext : DbContext
{
    public DbSet<Joke> Jokes { get; set; }
    private string? _connectionString;

    public JokeTrackerDbContext()
    {
    }
    public JokeTrackerDbContext(DbContextOptions<JokeTrackerDbContext> options)
            : base(options)
    {
    }

    // UNCOMMENT THIS WHEN MAKING MIGRATIONS
    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    // {
    //     options.UseSqlite($"Data Source={_connectionString}");
    // }
}
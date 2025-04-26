using Microsoft.EntityFrameworkCore;
using XPlat.Models;

namespace XPlat.Services
{
    static public class JokeDbContextFactory
    {

        static public JokeTrackerDbContext Create(string dbPath)
        {
            if (string.IsNullOrEmpty(dbPath))
            {
                throw new InvalidOperationException("No database selected.");
            }

            var options = new DbContextOptionsBuilder<JokeTrackerDbContext>()
                .UseSqlite($"Data Source={dbPath}")
                .Options;

            var context = new JokeTrackerDbContext(options);
            context.Database.Migrate();
            return context;
        }
    }

}
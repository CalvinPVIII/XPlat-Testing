using Microsoft.EntityFrameworkCore;
using XPlat.Models;

namespace XPlat.Services
{
    public class JokeDbContextFactory
    {
        private readonly CurrentDbService _currentDbService;

        public JokeDbContextFactory(CurrentDbService currentDbService)
        {
            _currentDbService = currentDbService;
        }

        public JokeTrackerDbContext CreateDbContext()
        {
            var dbPath = _currentDbService.CurrentDbPath;

            if (string.IsNullOrEmpty(dbPath))
            {
                throw new InvalidOperationException("No database selected.");
            }

            var options = new DbContextOptionsBuilder<JokeTrackerDbContext>()
                .UseSqlite($"Data Source={dbPath}")
                .Options;

            return new JokeTrackerDbContext(options);
        }
    }

}
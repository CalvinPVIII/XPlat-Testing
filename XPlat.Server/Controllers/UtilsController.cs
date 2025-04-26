using System.Text;
using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using XPlat.Models;
using XPlat.Services;

namespace XPlat.Controllers
{
    public class UtilsController : WebApiController
    {
        private readonly string _databasesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "databases");
        private readonly CurrentDbService _dbService;

        public UtilsController(CurrentDbService dbService)
        {
            _dbService = dbService;
        }


        [Route(HttpVerbs.Get, "/create-db")] // should be post but is get for testing purposes
        public async Task<object> Create()
        {
            if (!Directory.Exists(_databasesFolder))
                Directory.CreateDirectory(_databasesFolder);

            string dbName = GenerateRandomCode(4);
            // Combine path with filename
            string filePath = Path.Combine(_databasesFolder, $"{dbName}.db");

            System.IO.File.Create(filePath);
            return new { status = "success", message = $"DB Created at {filePath}" };
        }

        [Route(HttpVerbs.Get, "/get-all")]
        public async Task<object> GetAllDbs()
        {
            if (!Directory.Exists(_databasesFolder))
                Directory.CreateDirectory(_databasesFolder);

            var dbNames = Directory.EnumerateFiles(_databasesFolder).Select(Path.GetFileName);
            return new { status = "success", message = dbNames };
        }

        [Route(HttpVerbs.Get, "/current-db")]
        public async Task<object> GetCurrentDb()
        {
            return new { currentDb = Path.GetFileNameWithoutExtension(_dbService.CurrentDbPath) };
        }

        [Route(HttpVerbs.Get, "/select-db")]
        public async Task<object> SelectDatabase([QueryField] string dbName)
        {
            var fullPath = Path.Combine(_databasesFolder, $"{dbName}.db");

            if (!File.Exists(fullPath))
            {
                return new { status = "error", message = "Database not found." };
            }

            _dbService.CurrentDbPath = fullPath;

            return new { status = "success", activeDb = dbName };
        }




        private static string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            StringBuilder result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
    }
}
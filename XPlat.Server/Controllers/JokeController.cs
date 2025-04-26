using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using XPlat.Models;
using XPlat.Services;

namespace XPlat.Controllers
{
    public class JokeController : WebApiController
    {
        private readonly CurrentDbService _dbService;

        public JokeController(CurrentDbService dbService)
        {
            _dbService = dbService;
        }

        [Route(HttpVerbs.Get, "/joke")]
        public async Task<object> Index()
        {
            return new { joke = "You Better Go Catch it!!!!" };
        }

        [Route(HttpVerbs.Get, "/all-jokes")]
        public async Task<object> Read()
        {
            await using var db = JokeDbContextFactory.Create(_dbService.CurrentDbPath);
            var jokes = db.Jokes.ToArray();
            return new { jokes };
        }


        [Route(HttpVerbs.Get, "/seed-jokes")]
        public async Task<object> Seed()
        {
            Random rnd = new Random();
            await using var db = JokeDbContextFactory.Create(_dbService.CurrentDbPath);
            for (int i = 0; i < 1000; i++)
            {
                string setup = rnd.Next(1, 100).ToString();
                string punch = rnd.Next(1, 100).ToString();

                var joke = new Joke() { Setup = setup, Punchline = punch };
                db.Jokes.Add(joke);
            }
            db.SaveChanges();
            return new { message = "Added 1000 jokes" };
        }

        [Route(HttpVerbs.Post, "/add-joke")]
        public async Task<object> AddJoke([JsonData] Joke joke)
        {
            Console.WriteLine(joke.Setup);
            Console.WriteLine(joke.Punchline);
            await using var db = JokeDbContextFactory.Create(_dbService.CurrentDbPath);
            db.Jokes.Add(joke);
            db.SaveChanges();
            return new { message = "added joke" };
        }

    }
}
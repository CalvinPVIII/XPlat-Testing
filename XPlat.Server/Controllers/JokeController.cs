using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using XPlat.Models;

namespace XPlat.Controllers
{
    public class JokeController : WebApiController
    {

        private readonly JokeTrackerDbContext _context;

        [Route(HttpVerbs.Get, "/joke")]
        public async Task<object> Index()
        {
            return new { joke = "You Better Go Catch it!!!!" };
        }

        [Route(HttpVerbs.Get, "/joke")]
        public async Task<object> Read()
        {
            var jokes = _context.Jokes.ToArray();
            return new { jokes };
        }


    }
}
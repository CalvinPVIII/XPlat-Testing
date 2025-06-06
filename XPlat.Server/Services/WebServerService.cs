using System;
using EmbedIO;
using EmbedIO.Cors;
using EmbedIO.WebApi;
using Microsoft.Extensions.DependencyInjection;
using XPlat.Controllers;

namespace XPlat.Services
{
    public class LocalWebServerService : IDisposable
    {
        private WebServer _server;

        public LocalWebServerService(IServiceProvider services)
        {
            var url = "http://127.0.0.1:9696/";
            _server = new WebServer(options => options.WithUrlPrefix(url))
      // Add CORS support to allow any origin
      .WithModule(new CorsModule("/api"))
    .WithWebApi("/api", m =>
    {
        m.WithController(() => services.GetRequiredService<JokeController>());
        m.WithController(() => services.GetRequiredService<UtilsController>());
    });


            _server.StateChanged += (s, e) =>
                Console.WriteLine($"WebServer New State - {e.NewState}");
        }

        public async void Start() => await _server.RunAsync();

        public void Dispose() => _server?.Dispose();
    }

}
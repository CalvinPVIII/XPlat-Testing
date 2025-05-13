// using Microsoft.Extensions.DependencyInjection;
// using XPlat;
// using XPlat.Controllers;
// using XPlat.Services;



// // DEPENDENCY INJECTIONS ==============
// var services = new ServiceCollection();

// services.AddSingleton<CurrentDbService>(provider =>
// {
//     return new CurrentDbService
//     {
//         CurrentDbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "databases", "default.db")
//     };
// });



// services.AddTransient<UtilsController>();
// services.AddTransient<JokeController>();

// var serviceProvider = services.BuildServiceProvider();

// Console.WriteLine("Starting WebServer");
// var _webServer = new LocalWebServerService(serviceProvider);
// _webServer.Start();

// Console.WriteLine("Press Enter to exit...");
// Console.ReadLine();
using Microsoft.Extensions.Logging;

using XPlat.Controllers;
using XPlat.Services;

namespace XPlat.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddHybridWebView();



		// DEPENDENCY INJECTIONS ==============
		var services = new ServiceCollection();

		services.AddSingleton(provider =>
		{
			return new CurrentDbService
			{
				CurrentDbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "databases", "default.db")
			};
		});



		services.AddTransient<UtilsController>();
		services.AddTransient<JokeController>();
		var serviceProvider = services.BuildServiceProvider();

		Console.WriteLine("Starting WebServer");
		var _webServer = new LocalWebServerService(serviceProvider);
		_webServer.Start();




#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

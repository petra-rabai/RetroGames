using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace RetroGames
{
	internal class Program
	{
		private static void Main()
		{
			ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
			BuildConfig(configurationBuilder);

			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(configurationBuilder.Build())
				.Enrich.FromLogContext()
				.WriteTo.Console()
				.CreateLogger();

			Log.Logger.Information("Application starting");

			IHost host = Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) =>
				{
					services.AddTransient<IMainService, MainService>();
				})
				.UseSerilog()
				.Build();

			IMainService MainService = ActivatorUtilities.CreateInstance<MainService>(host.Services);
			MainService.Initialize();

			

		}

		static void BuildConfig(IConfigurationBuilder configurationBuilder)
		{
			configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Prodaction"}.json", optional: true)
				.AddEnvironmentVariables();
		}
		
	}
}
using Autofac;
using System;

namespace RetroGames
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			IOCContainerConfig iOCContainerConfig = new();
			IContainer iOCContainer = iOCContainerConfig.Configure();
			ILifetimeScope scope = iOCContainer.BeginLifetimeScope();
			Application application = scope.Resolve<Application>();
			
			application.Run();
			
			Console.ReadLine();
		}
	}
}
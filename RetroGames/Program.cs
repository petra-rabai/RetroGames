using Autofac;
using System;

namespace RetroGames
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			IContainer iOCContainer = ContainerConfig.Configure();
			ILifetimeScope scope = iOCContainer.BeginLifetimeScope();

			IApplication application = scope.Resolve<IApplication>();

			application.Run();

			Console.ReadLine();
		}
	}
}
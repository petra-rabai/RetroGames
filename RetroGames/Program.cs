using Autofac;
using System;

namespace RetroGames
{
	internal class Program
	{
		private static void Main()
		{
			IContainer iOcContainer = ContainerConfig.Configure();
			ILifetimeScope scope = iOcContainer.BeginLifetimeScope();

			IApplication application = scope.Resolve<IApplication>();

			application.Run();

			Console.ReadLine();
		}
	}
}
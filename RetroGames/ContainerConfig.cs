using Autofac;
using System.Linq;
using System.Reflection;

namespace RetroGames
{
	public class ContainerConfig
	{
		public IContainer Configure()
		{
			ContainerBuilder containerBuilder = new();
			
			containerBuilder.RegisterType<Application>().As<IApplication>();

			containerBuilder.RegisterAssemblyTypes(Assembly.Load(nameof(RetroGames)))
				.Where(retroGamesType => retroGamesType.Namespace.Contains("Games"))
				.As(retroGamesType => retroGamesType.GetInterfaces().FirstOrDefault(interfaceType => interfaceType.Name == "I" + retroGamesType.Name));

			containerBuilder.RegisterAssemblyTypes(Assembly.Load(nameof(RetroGames)))
				.Where(retroGamesType => retroGamesType.Namespace.Contains("Person"))
				.As(retroGamesType => retroGamesType.GetInterfaces().FirstOrDefault(interfaceType => interfaceType.Name == "I" + retroGamesType.Name));

			return containerBuilder.Build();
		}
	}
}

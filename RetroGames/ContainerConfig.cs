using Autofac;
using AutofacSerilogIntegration;
using System.IO.Abstractions;
using System.Reflection;

namespace RetroGames
{
	public static class ContainerConfig
	{

		public static IContainer Configure()
		{
			ContainerBuilder containerBuilder = new();
			
			RegisterDependencies(containerBuilder);

			return containerBuilder.Build();
		}

		private static void RegisterDependencies(ContainerBuilder containerBuilder)
		{
			containerBuilder.RegisterLogger();

			containerBuilder.RegisterType<FileSystem>()
							.As<IFileSystem>()
							.SingleInstance();

			Assembly dependencies = Assembly.GetExecutingAssembly();
			containerBuilder.RegisterAssemblyTypes(dependencies)
							.SingleInstance()
							.InNamespace("RetroGames")
							.AsImplementedInterfaces();

		}
	}
}
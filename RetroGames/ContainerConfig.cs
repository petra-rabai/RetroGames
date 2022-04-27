using Autofac;
using AutofacSerilogIntegration;
using RetroGames.Game;
using RetroGames.Game.Actions;
using RetroGames.Game.DirectoryStructure;
using RetroGames.Game.UI;
using RetroGames.Person.Actions;
using RetroGames.Person.Data;
using RetroGames.Person.Security;
using System.IO.Abstractions;

namespace RetroGames
{
	public static class ContainerConfig
	{
		public static IContainer Configure()
		{
			ContainerBuilder containerBuilder = new();
			containerBuilder.RegisterLogger();
			containerBuilder.RegisterType<Application>().As<IApplication>().SingleInstance()
							.SingleInstance();
			containerBuilder.RegisterType<Drive>().As<IDrive>().SingleInstance()
							.SingleInstance();
			containerBuilder.RegisterType<GameDirectory>().As<IGameDirectory>()
							.SingleInstance();
			containerBuilder.RegisterType<GameFile>().As<IGameFile>()
							.SingleInstance();
			containerBuilder.RegisterType<FileSystem>().As<IFileSystem>()
							.SingleInstance();
			containerBuilder.RegisterType<GameMenu>().As<IGameMenu>()
							.SingleInstance();
			containerBuilder.RegisterType<GameMenuSelector>().As<IGameMenuSelector>()
							.SingleInstance();
			containerBuilder.RegisterType<GameControl>().As<IGameControl>()
							.SingleInstance();
			containerBuilder.RegisterType<MainScreenUi>().As<IMainScreenUi>()
							.SingleInstance();
			containerBuilder.RegisterType<Screen>().As<IScreen>()
							.SingleInstance();
			containerBuilder.RegisterType<Installation>().As<IInstallation>()
							.SingleInstance();
			containerBuilder.RegisterType<InstallationUi>().As<IInstallationUi>()
							.SingleInstance();
			containerBuilder.RegisterType<RegistrationUi>().As<IRegistrationUi>()
							.SingleInstance();
			containerBuilder.RegisterType<Login>().As<ILogin>()
							.SingleInstance();
			containerBuilder.RegisterType<Registration>().As<IRegistration>()
							.SingleInstance();
			containerBuilder.RegisterType<PlayerInteraction>().As<IPlayerInteraction>()
							.SingleInstance();
			containerBuilder.RegisterType<Player>().As<IPlayer>()
							.SingleInstance();
			containerBuilder.RegisterType<PasswordHandler>().As<IPasswordHandler>()
							.SingleInstance();
			containerBuilder.RegisterType<Password>().As<IPassword>()
							.SingleInstance();
			containerBuilder.RegisterType<PasswordValidator>().As<IPasswordValidator>()
							.SingleInstance();
			containerBuilder.RegisterType<Email>().As<IEmail>()
							.SingleInstance();
			containerBuilder.RegisterType<EmailValidator>().As<IEmailValidator>()
							.SingleInstance();
			containerBuilder.RegisterType<User>().As<IUser>()
							.SingleInstance();
			containerBuilder.RegisterType<RegistrationData>().As<IRegistrationData>()
							.SingleInstance();
			containerBuilder.RegisterType<StringCryptographer>().As<IStringCryptographer>()
							.SingleInstance();

			return containerBuilder.Build();
		}

	}
}
using Autofac;
using RetroGames.Game;
using RetroGames.Game.Actions;
using RetroGames.Game.DirectoryStructure;
using RetroGames.Game.UI;
using RetroGames.Person.Actions;
using RetroGames.Person.Data;
using RetroGames.Person.Security;

namespace RetroGames
{
	public static class ContainerConfig
	{
		public static IContainer Configure()
		{
			ContainerBuilder containerBuilder = new();

			containerBuilder.RegisterType<Application>().As<IApplication>();
			containerBuilder.RegisterType<Drive>().As<IDrive>();
			containerBuilder.RegisterType<GameDirectory>().As<IGameDirectory>();
			containerBuilder.RegisterType<GameFile>().As<IGameFile>();
			containerBuilder.RegisterType<GameMenu>().As<IGameMenu>();
			containerBuilder.RegisterType<MainScreenUI>().As<IMainScreenUI>();
			containerBuilder.RegisterType<MainScreen>().As<IMainScreen>();
			containerBuilder.RegisterType<Installation>().As<IInstallation>();
			containerBuilder.RegisterType<InstallationUI>().As<IInstallationUI>();
			containerBuilder.RegisterType<RegistrationUI>().As<IRegistrationUI>();
			containerBuilder.RegisterType<Login>().As<ILogin>();
			containerBuilder.RegisterType<Registration>().As<IRegistration>();
			containerBuilder.RegisterType<PlayerInteraction>().As<IPlayerInteraction>();
			containerBuilder.RegisterType<Player>().As<IPlayer>();
			containerBuilder.RegisterType<PasswordHandler>().As<IPasswordHandler>();
			containerBuilder.RegisterType<Password>().As<IPassword>();
			containerBuilder.RegisterType<PasswordValidator>().As<IPasswordValidator>();
			containerBuilder.RegisterType<Email>().As<IEmail>();
			containerBuilder.RegisterType<EmailValidator>().As<IEmailValidator>();
			containerBuilder.RegisterType<User>().As<IUser>();
			containerBuilder.RegisterType<RegistrationData>().As<IRegistrationData>();
			containerBuilder.RegisterType<StringCryptographer>().As<IStringCryptographer>();

			return containerBuilder.Build();
		}
	}
}
using System;

namespace RetroGames
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			IGameMenu gameMenu = new GameMenu();
			IMainScreenUI mainScreenUI = new MainScreenUI(gameMenu);
			MainScreen mainScreen = new(mainScreenUI);
			IPlayerInteraction playerInteraction = new PlayerInteraction();
			IDrive drive = new Drive(playerInteraction);
			IGameDirectory gameDirectory = new GameDirectory(drive);
			IGameFile gameFile = new GameFile(drive, gameDirectory);
			IInstallationUI installationUI = new InstallationUI();
			IInstallation installation = new Installation(gameFile, installationUI, mainScreen, drive);
			IUser user = new User();
			IEmailValidator emailValidator = new EmailValidator();
			IEmail email = new Email(emailValidator);
			IPassword password = new Password();
			IPasswordValidator passwordValidator = new PasswordValidator();
			IStringCryptographer IstringCryptographer = new StringCryptographer();
			IPasswordHandler passwordHandler = new PasswordHandler(password, passwordValidator, IstringCryptographer);
			IRegistrationUI registrationUI = new RegistrationUI();
			IRegistration registration = new Registration(registrationUI, installation, user, email, playerInteraction, passwordHandler);

			GameMenuNavigation gameMenuNavigation = new(playerInteraction, registration, gameMenu, installation);

			mainScreen.MainScreenInitialize();
			gameMenuNavigation.GetChoosedMenu();
			gameMenuNavigation.MenuNavigation();

			Console.ReadLine();
		}
	}
}
using Moq;
using NUnit.Framework;
using RetroGames;
using RetroGames.Games;
using RetroGames.Games.Actions;
using RetroGames.Games.DirectoryStructure;
using RetroGames.Games.UI;
using RetroGames.Person.Actions;
using RetroGames.Person.Data;
using RetroGames.Person.Security;
using System.IO.Abstractions;

namespace RetroGamesTests
{
	public class RegistrationTests
	{
		[TestCase('Y')]
		[TestCase('N')]
		[Test]
		public void SaveDecesionCheckSuccess(char testDecesion)
		{
			IRegistrationUI registrationUI = new RegistrationUI();
			IInstallationUI installationUI = new InstallationUI();
			IGameMenu gameMenu = new GameMenu();
			IMainScreenUI mainScreenUI = new MainScreenUI(gameMenu);
			IMainScreen mainScreen = new MainScreen(mainScreenUI);
			IPlayerInteraction playerInteraction = new PlayerInteraction();

			Mock<IFileSystem> fileSystem = new(MockBehavior.Strict);

			Drive drive = new(playerInteraction, fileSystem.Object);

			GameDirectory gameDirectory = new(drive, fileSystem.Object);
			GameFile gameFile = new GameFile(drive, gameDirectory, fileSystem.Object);
			IInstallation installation = new Installation(gameFile, installationUI, mainScreen, drive);
			IUser user = new User();
			IEmailValidator emailValidator = new EmailValidator();
			IEmail email = new Email(emailValidator);
			IPassword password = new Password();
			IPasswordValidator passwordValidator = new PasswordValidator();
			IStringCryptographer IstringCryptographer = new StringCryptographer();
			IPasswordHandler passwordHandler = new PasswordHandler(password, passwordValidator, IstringCryptographer);

			Registration registration = new Registration(registrationUI, installation, user, email, playerInteraction, passwordHandler);
			StringCryptographer stringCryptographer = new StringCryptographer();

			registration.Name = "Test User";
			registration.LoginName = "test1";
			registration.Email = "test@test.com";
			stringCryptographer.EncryptProcess("Rp!.19840716.!");
			
			registration.Password = stringCryptographer.EncryptResult;

			registration.SaveDecesionCheck(testDecesion);

			Assert.NotNull(registration.IsRegistered);
		}

		[TestCase(true)]
		[TestCase(false)]
		[Test]
		public void IsUserRegisteredSuccess(bool registred)
		{
			IRegistrationUI registrationUI = new RegistrationUI();
			IInstallationUI installationUI = new InstallationUI();
			IGameMenu gameMenu = new GameMenu();
			IMainScreenUI mainScreenUI = new MainScreenUI(gameMenu);
			IMainScreen mainScreen = new MainScreen(mainScreenUI);
			IPlayerInteraction playerInteraction = new PlayerInteraction();
			Mock<IFileSystem> fileSystem = new(MockBehavior.Strict);

			Drive drive = new(playerInteraction, fileSystem.Object);

			GameDirectory gameDirectory = new(drive, fileSystem.Object);
			GameFile gameFile = new GameFile(drive, gameDirectory, fileSystem.Object);
			IInstallation installation = new Installation(gameFile, installationUI, mainScreen, drive);
			IUser user = new User();
			IEmailValidator emailValidator = new EmailValidator();
			IEmail email = new Email(emailValidator);
			IPassword password = new Password();
			IPasswordValidator passwordValidator = new PasswordValidator();
			IStringCryptographer IstringCryptographer = new StringCryptographer();
			IPasswordHandler passwordHandler = new PasswordHandler(password, passwordValidator, IstringCryptographer);

			Registration registration = new Registration(registrationUI, installation, user, email, playerInteraction, passwordHandler);

			registration.IsUserRegistered(registred);

			Assert.AreEqual(registred, registration.IsRegistered);
		}
	}
}
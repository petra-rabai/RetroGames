using Moq;
using NUnit.Framework;
using FluentAssertions;
using RetroGames;
using RetroGames.Person.Actions;
using RetroGames.Person.Data;
using RetroGames.Person.Security;
using System.IO.Abstractions;
using RetroGames.Game;
using RetroGames.Game.Actions;
using RetroGames.Game.DirectoryStructure;
using RetroGames.Game.UI;

namespace RetroGamesTests
{
	public class RegistrationTests
	{

		[Test]
		public void CheckUserRegistrationFormInitialize()
		{
			string Email = "test@test.com";
			string Password = "RpT1x46!x";
			string firstName = "Test";
			string lastName = "Last";
			string loginName = "loginName";
			bool mockIsPasswordHandling = true;
			bool mockInstallationSuccess = true;
			Mock<IRegistrationUI> mockRegistrationUI = new();
			mockRegistrationUI
				.Setup(mockSetup => mockSetup.FormTitle())
				.Verifiable();
			mockRegistrationUI
				.Setup(mockSetup => mockSetup.FormFirstName())
				.Verifiable();
			mockRegistrationUI
				.Setup(mockSetup => mockSetup.FormLastName())
				.Verifiable();
			mockRegistrationUI
				.Setup(mockSetup => mockSetup.FormLoginName())
				.Verifiable();
			mockRegistrationUI
				.Setup(mockSetup => mockSetup.FormPassword())
				.Verifiable();
			mockRegistrationUI
				.Setup(mockSetup => mockSetup.FormEmail())
				.Verifiable();
			Mock<IEmail> mockEmail = new();
			mockEmail
				.Setup(mockSetup => mockSetup.GetPlayerEmail())
				.Returns(() => { return Email; });
			Mock<IPasswordHandler> mockPasswordHandler = new();
			mockPasswordHandler
				.Setup(mockSetup => mockSetup.GetPlayerPassword())
				.Returns(() => { return Password; });
			mockPasswordHandler
				.Setup(mockSetup => mockSetup.CheckPasswordHandling(Password))
				.Returns(() => { return mockIsPasswordHandling; });
			Mock<IUser> mockUser = new();
			mockUser
				.Setup(mockSetup => mockSetup.FirstName)
				.Returns(firstName);
			mockUser
				.Setup(mockSetup => mockSetup.LastName)
				.Returns(lastName);
			mockUser
				.Setup(mockSetup => mockSetup.GetPlayerLoginName())
				.Returns(() => { return loginName; });
			mockUser
				.Setup(mockSetup => mockSetup.GetPlayerLastName())
				.Returns(() => { return lastName; });
			mockUser
				.Setup(mockSetup => mockSetup.GetPlayerFirstName())
				.Returns(() => { return firstName; });

			Mock<IInstallation> mockInstallation = new();
			mockInstallation
				.Setup(mockSetup => mockSetup.CheckInstallationSuccess())
				.Returns(() => { return mockInstallationSuccess; });


		}


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
			IInstallation installation = new Installation(gameFile, installationUI, mainScreen, drive,playerInteraction);
			IUser user = new User(playerInteraction);
			IEmailValidator emailValidator = new EmailValidator();
			IEmail email = new Email(emailValidator, playerInteraction);
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
			IInstallation installation = new Installation(gameFile, installationUI, mainScreen, drive,playerInteraction);
			IUser user = new User(playerInteraction);
			IEmailValidator emailValidator = new EmailValidator();
			IEmail email = new Email(emailValidator, playerInteraction);
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
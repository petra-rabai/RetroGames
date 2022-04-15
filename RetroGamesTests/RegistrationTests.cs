using Moq;
using NUnit.Framework;
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
			string email = "test@test.com";
			string password = "RpT1x46!x";
			string firstName = "Test";
			string lastName = "Last";
			string loginName = "loginName";
			bool mockIsPasswordHandling = true;
			bool mockInstallationSuccess = true;
			Mock<IRegistrationUi> mockRegistrationUi = new();
			mockRegistrationUi
				.Setup(mockSetup => mockSetup.FormTitle())
				.Verifiable();
			mockRegistrationUi
				.Setup(mockSetup => mockSetup.FormFirstName())
				.Verifiable();
			mockRegistrationUi
				.Setup(mockSetup => mockSetup.FormLastName())
				.Verifiable();
			mockRegistrationUi
				.Setup(mockSetup => mockSetup.FormLoginName())
				.Verifiable();
			mockRegistrationUi
				.Setup(mockSetup => mockSetup.FormPassword())
				.Verifiable();
			mockRegistrationUi
				.Setup(mockSetup => mockSetup.FormEmail())
				.Verifiable();
			Mock<IEmail> mockEmail = new();
			mockEmail
				.Setup(mockSetup => mockSetup.GetPlayerEmail())
				.Returns(() => { return email; });
			Mock<IPasswordHandler> mockPasswordHandler = new();
			mockPasswordHandler
				.Setup(mockSetup => mockSetup.GetPlayerPassword())
				.Returns(() => { return password; });
			mockPasswordHandler
				.Setup(mockSetup => mockSetup.CheckPasswordHandling(password))
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
			IRegistrationUi registrationUi = new RegistrationUi();
			IInstallationUi installationUi = new InstallationUi();
			IGameMenu gameMenu = new GameMenu();
			IMainScreenUi mainScreenUi = new MainScreenUi(gameMenu);
			IMainScreen mainScreen = new MainScreen(mainScreenUi);
			IPlayerInteraction playerInteraction = new PlayerInteraction();

			Mock<IFileSystem> fileSystem = new(MockBehavior.Strict);

			Drive drive = new(playerInteraction, fileSystem.Object);

			GameDirectory gameDirectory = new(drive, fileSystem.Object);
			GameFile gameFile = new(drive, gameDirectory, fileSystem.Object);
			IInstallation installation = new Installation(gameFile, installationUi, mainScreen, drive,playerInteraction);
			IUser user = new User(playerInteraction);
			IEmailValidator emailValidator = new EmailValidator();
			IEmail email = new Email(emailValidator, playerInteraction);
			IPassword password = new Password();
			IPasswordValidator passwordValidator = new PasswordValidator();
			IStringCryptographer istringCryptographer = new StringCryptographer();
			IPasswordHandler passwordHandler = new PasswordHandler(password, passwordValidator, istringCryptographer);

			Registration registration = new(registrationUi, installation, user, email, playerInteraction, passwordHandler);
			StringCryptographer stringCryptographer = new();

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
			IRegistrationUi registrationUi = new RegistrationUi();
			IInstallationUi installationUi = new InstallationUi();
			IGameMenu gameMenu = new GameMenu();
			IMainScreenUi mainScreenUi = new MainScreenUi(gameMenu);
			IMainScreen mainScreen = new MainScreen(mainScreenUi);
			IPlayerInteraction playerInteraction = new PlayerInteraction();
			Mock<IFileSystem> fileSystem = new(MockBehavior.Strict);

			Drive drive = new(playerInteraction, fileSystem.Object);

			GameDirectory gameDirectory = new(drive, fileSystem.Object);
			GameFile gameFile = new(drive, gameDirectory, fileSystem.Object);
			IInstallation installation = new Installation(gameFile, installationUi, mainScreen, drive,playerInteraction);
			IUser user = new User(playerInteraction);
			IEmailValidator emailValidator = new EmailValidator();
			IEmail email = new Email(emailValidator, playerInteraction);
			IPassword password = new Password();
			IPasswordValidator passwordValidator = new PasswordValidator();
			IStringCryptographer istringCryptographer = new StringCryptographer();
			IPasswordHandler passwordHandler = new PasswordHandler(password, passwordValidator, istringCryptographer);

			Registration registration = new(registrationUi, installation, user, email, playerInteraction, passwordHandler);

			registration.IsUserRegistered(registred);

			Assert.AreEqual(registred, registration.IsRegistered);
		}
	}
}
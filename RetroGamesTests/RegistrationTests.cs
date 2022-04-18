using FluentAssertions;
using Moq;
using NUnit.Framework;
using RetroGames.Game;
using RetroGames.Game.Actions;
using RetroGames.Game.UI;
using RetroGames.Person.Actions;
using RetroGames.Person.Data;
using System.IO;
using System.IO.Abstractions;

namespace RetroGamesTests
{
	public class RegistrationTests
	{
		[TestCase('Y')]
		[Test]
		public void CheckUserRegistrationFormInitialize(char testkey)
		{
			string email = "test@test.com";
			string password = "RpT1x46!x";
			string firstName = "Test";
			string lastName = "Last";
			string loginName = "loginName";
			bool mockIsPasswordHandling = true;
			bool mockInstallationSuccess = true;
			char mockPlayerKey = testkey;
			string mockFilePath = "C:\\Test\\Test.xml";
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

			mockInstallation
				.Setup(mockSetup => mockSetup.UserFilePath)
				.Returns(mockFilePath);

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			Mock<IScreen> mockScreen = new();
			mockScreen
				.Setup(mockSetup => mockSetup.ScreenInitialize())
				.Verifiable();


			IFileSystem fileSystem = new FileSystem();

			Registration registration = new(mockRegistrationUi.Object, mockScreen.Object,mockInstallation.Object, mockUser.Object, mockEmail.Object, playerInteraction.Object, mockPasswordHandler.Object, fileSystem);

			Stream testxml = fileSystem.File.Create(mockFilePath);
			testxml.Dispose();
			testxml.Close();

			registration.UserRegistration();

			registration.IsRegistered.Should().BeTrue();

			fileSystem.File.Delete(mockFilePath);
		}

		[TestCase('N')]
		[Test]
		public void CheckUserRegistrationFailed(char testkey)
		{
			string email = "test@test.com";
			string password = "RpT1x46!x";
			string firstName = "Test";
			string lastName = "Last";
			string loginName = "loginName";
			bool mockIsPasswordHandling = true;
			bool mockInstallationSuccess = true;
			char mockPlayerKey = testkey;
			string mockFilePath = "C:\\Test\\Test.xml";
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

			mockInstallation
				.Setup(mockSetup => mockSetup.UserFilePath)
				.Returns(mockFilePath);

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			Mock<IScreen> mockScreen = new();
			mockScreen
				.Setup(mockSetup => mockSetup.ScreenInitialize())
				.Verifiable();

			IFileSystem fileSystem = new FileSystem();

			Registration registration = new(mockRegistrationUi.Object, mockScreen.Object,mockInstallation.Object, mockUser.Object, mockEmail.Object, playerInteraction.Object, mockPasswordHandler.Object, fileSystem);

			Stream testxml = fileSystem.File.Create(mockFilePath);
			testxml.Dispose();
			testxml.Close();

			registration.UserRegistration();

			registration.IsRegistered.Should().BeFalse();

			fileSystem.File.Delete(mockFilePath);
		}

		[TestCase('N')]
		[Test]
		public void CheckUserNotWantToSaveRegistrationData(char testDecison)
		{
			string email = "test@test.com";
			string password = "RpT1x46!x";
			string firstName = "Test";
			string lastName = "Last";
			string loginName = "loginName";
			bool mockIsPasswordHandling = true;
			bool mockInstallationSuccess = true;
			char mockPlayerKey = testDecison;
			string mockFilePath = "C:\\Test\\Test.xml";
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

			mockInstallation
				.Setup(mockSetup => mockSetup.UserFilePath)
				.Returns(mockFilePath);

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			Mock<IScreen> mockScreen = new();
			mockScreen
				.Setup(mockSetup => mockSetup.ScreenInitialize())
				.Verifiable();

			IFileSystem fileSystem = new FileSystem();

			Registration registration = new(mockRegistrationUi.Object, mockScreen.Object, mockInstallation.Object, mockUser.Object, mockEmail.Object, playerInteraction.Object, mockPasswordHandler.Object, fileSystem);
			registration.Name = firstName + lastName;
			registration.LoginName = loginName;
			registration.Password = password;
			registration.Email = email;

			registration.SaveDecesionCheck(testDecison);

			registration.IsRegistered.Should().BeFalse();
		}
	}
}
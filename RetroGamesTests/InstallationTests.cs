using FluentAssertions;
using Moq;
using NUnit.Framework;
using RetroGames.Game;
using RetroGames.Game.Actions;
using RetroGames.Game.DirectoryStructure;
using RetroGames.Game.UI;
using RetroGames.Person.Actions;
using System.Collections.Generic;

namespace RetroGamesTests
{
	public class InstallationTests
	{
		[Test]
		public void CheckInstallationSuccess()
		{
			bool isInstallationSuccess;
			bool mockIsWaitforInput = true;
			int mockDrivelistKey = 0;

			string mockDrivelistName = "C:\\";
			string mockChoosedMenu = "Installation";
			bool mockIsNavigationSuccess = true;
			Dictionary<int, string> mockDriveList = new()
			{
				[0] = "C:\\"
			};
			bool mockIsGameFilesExist = true;
			Mock<IInstallationUi> mockInstallationUi = new();
			mockInstallationUi
				.Setup(mockSetup => mockSetup.InstallationUiInitialize())
				.Verifiable();
			mockInstallationUi
				.Setup(mockSetup => mockSetup.DrivelistUi(mockDrivelistKey, mockDrivelistName))
				.Verifiable();
			Mock<IScreen> mockScreen = new();
			mockScreen
				.Setup(mockSetup => mockSetup.WaitForInputSuccess())
				.Returns(() => { return mockIsWaitforInput; });
			mockScreen
				.Setup(mockSetup => mockSetup.ScreenInitialize())
				.Verifiable();
			Mock<IDrive> mockDrive = new();
			mockDrive
				.Setup(mockSetup => mockSetup.GetDriveList())
				.Returns(mockDriveList);
			Mock<IGameFile> mockGameFile = new();
			mockGameFile
				.Setup(mockSetup => mockSetup.CheckGameFilesCreated())
				.Returns(() => { return mockIsGameFilesExist; });
			
			Mock<IGameMenuSelector> mockGameMenuNavigation = new();
			mockGameMenuNavigation
				.Setup(mockSetup => mockSetup.ChoosedMenu)
				.Returns(mockChoosedMenu);
			mockGameMenuNavigation
				.Setup(mockSetup => mockSetup.isNavigationSuccess)
				.Returns(mockIsNavigationSuccess);


			Installation installation = new(mockGameFile.Object, mockInstallationUi.Object, mockScreen.Object, mockDrive.Object, mockGameMenuNavigation.Object);

			isInstallationSuccess = installation.CheckInstallationSuccess();

			isInstallationSuccess.Should().BeTrue();
		}

		[Test]
		public void CheckInstallationFailed()
		{
			bool isInstallationSuccess;
			bool mockIsWaitforInput = true;
			int mockDrivelistKey = 0;
			char mockPlayerKey = '0';
			string mockDrivelistName = "C:\\";
			Dictionary<int, string> mockDriveList = new()
			{
				[0] = "C:\\"
			};
			bool mockIsGameFilesExist = false;
			Mock<IInstallationUi> mockInstallationUi = new();
			mockInstallationUi
				.Setup(mockSetup => mockSetup.InstallationUiInitialize())
				.Verifiable();
			mockInstallationUi
				.Setup(mockSetup => mockSetup.DrivelistUi(mockDrivelistKey, mockDrivelistName))
				.Verifiable();
			Mock<IScreen> mockMainScreen = new();
			mockMainScreen
				.Setup(mockSetup => mockSetup.WaitForInputSuccess())
				.Returns(() => { return mockIsWaitforInput; });
			Mock<IPlayerInteraction> mockPlayerInteraction = new(MockBehavior.Strict);
			mockPlayerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });
			Mock<IDrive> mockDrive = new();
			mockDrive
				.Setup(mockSetup => mockSetup.GetDriveList())
				.Returns(mockDriveList);
			Mock<IGameFile> mockGameFile = new();
			mockGameFile
				.Setup(mockSetup => mockSetup.CheckGameFilesCreated())
				.Returns(() => { return mockIsGameFilesExist; });

			Installation installation = new(mockGameFile.Object, mockInstallationUi.Object, mockMainScreen.Object, mockDrive.Object, mockPlayerInteraction.Object);

			isInstallationSuccess = installation.CheckInstallationSuccess();

			isInstallationSuccess.Should().BeFalse();
		}

		[Test]
		public void CheckInstallationProcessSuccess()
		{
			bool isInstallationSuccess;
			bool mockIsWaitforInput = true;
			int mockDrivelistKey = 0;
			char mockPlayerKey = '0';
			string mockDrivelistName = "C:\\";
			Dictionary<int, string> mockDriveList = new()
			{
				[0] = "C:\\"
			};
			bool mockIsGameFilesExist = true;
			Mock<IInstallationUi> mockInstallationUi = new();
			mockInstallationUi
				.Setup(mockSetup => mockSetup.InstallationUiInitialize())
				.Verifiable();
			mockInstallationUi
				.Setup(mockSetup => mockSetup.DrivelistUi(mockDrivelistKey, mockDrivelistName))
				.Verifiable();
			Mock<IScreen> mockMainScreen = new();
			mockMainScreen
				.Setup(mockSetup => mockSetup.WaitForInputSuccess())
				.Returns(() => { return mockIsWaitforInput; });
			Mock<IPlayerInteraction> mockPlayerInteraction = new(MockBehavior.Strict);
			mockPlayerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });
			Mock<IDrive> mockDrive = new();
			mockDrive
				.Setup(mockSetup => mockSetup.GetDriveList())
				.Returns(mockDriveList);
			Mock<IGameFile> mockGameFile = new();
			mockGameFile
				.Setup(mockSetup => mockSetup.CheckGameFilesCreated())
				.Returns(() => { return mockIsGameFilesExist; });

			Installation installation = new(mockGameFile.Object, mockInstallationUi.Object, mockMainScreen.Object, mockDrive.Object, mockPlayerInteraction.Object);

			installation.InstallationProcess();

			isInstallationSuccess = installation.IsInstallationSuccess;

			isInstallationSuccess.Should().BeTrue();
		}

		[Test]
		public void CheckInstallationProcessFailed()
		{
			bool isInstallationSuccess;
			bool mockIsWaitforInput = true;
			int mockDrivelistKey = 0;
			char mockPlayerKey = 'K';
			string mockDrivelistName = "C:\\";
			Dictionary<int, string> mockDriveList = new()
			{
				[0] = "C:\\"
			};
			bool mockIsGameFilesExist = true;
			Mock<IInstallationUi> mockInstallationUi = new();
			mockInstallationUi
				.Setup(mockSetup => mockSetup.InstallationUiInitialize())
				.Verifiable();
			mockInstallationUi
				.Setup(mockSetup => mockSetup.DrivelistUi(mockDrivelistKey, mockDrivelistName))
				.Verifiable();
			Mock<IScreen> mockMainScreen = new();
			mockMainScreen
				.Setup(mockSetup => mockSetup.WaitForInputSuccess())
				.Returns(() => { return mockIsWaitforInput; });
			mockMainScreen
				.Setup(mockSetup => mockSetup.MainScreenInitialize())
				.Verifiable();
			Mock<IPlayerInteraction> mockPlayerInteraction = new(MockBehavior.Strict);
			mockPlayerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });
			Mock<IDrive> mockDrive = new();
			mockDrive
				.Setup(mockSetup => mockSetup.GetDriveList())
				.Returns(mockDriveList);
			mockDrive
				.Setup(mockSetup => mockSetup.GetDriveDecisionFromPlayer())
				.Returns(() => { return mockPlayerKey; });

			Mock<IGameFile> mockGameFile = new();
			mockGameFile
				.Setup(mockSetup => mockSetup.CheckGameFilesCreated())
				.Returns(() => { return mockIsGameFilesExist; });

			Installation installation = new(mockGameFile.Object, mockInstallationUi.Object, mockMainScreen.Object, mockDrive.Object, mockPlayerInteraction.Object);

			installation.InstallationProcess();

			isInstallationSuccess = installation.IsInstallationSuccess;

			isInstallationSuccess.Should().BeFalse();
		}
	}
}
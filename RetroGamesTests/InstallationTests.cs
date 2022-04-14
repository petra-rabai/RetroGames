using Moq;
using NUnit.Framework;
using FluentAssertions;
using RetroGames;
using RetroGames.Games;
using RetroGames.Games.Actions;
using RetroGames.Games.DirectoryStructure;
using RetroGames.Games.UI;
using RetroGames.Person.Actions;
using System.IO.Abstractions;
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
			char mockPlayerKey = '0';
			string mockDrivelistName = "C:\\";
			Dictionary<int, string> mockDriveList = new Dictionary<int, string>()
			{
				[0] = "C:\\"
			}; 
			bool mockIsGameFilesExist = true;
			Mock<IInstallationUI> mockInstallationUI = new();
			mockInstallationUI
				.Setup(mockSetup => mockSetup.InstallationUIInitialize())
				.Verifiable();
			mockInstallationUI
				.Setup(mockSetup => mockSetup.DrivelistUI(mockDrivelistKey, mockDrivelistName))
				.Verifiable();
			Mock<IMainScreen> mockMainScreen = new();
			mockMainScreen
				.Setup(mockSetup => mockSetup.WaitForInputSuccess())
				.Returns(()=> { return mockIsWaitforInput; });
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

			Installation installation = new(mockGameFile.Object,mockInstallationUI.Object,mockMainScreen.Object,mockDrive.Object,mockPlayerInteraction.Object);

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
			Dictionary<int, string> mockDriveList = new Dictionary<int, string>()
			{
				[0] = "C:\\"
			};
			bool mockIsGameFilesExist = false;
			Mock<IInstallationUI> mockInstallationUI = new();
			mockInstallationUI
				.Setup(mockSetup => mockSetup.InstallationUIInitialize())
				.Verifiable();
			mockInstallationUI
				.Setup(mockSetup => mockSetup.DrivelistUI(mockDrivelistKey, mockDrivelistName))
				.Verifiable();
			Mock<IMainScreen> mockMainScreen = new();
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

			Installation installation = new(mockGameFile.Object, mockInstallationUI.Object, mockMainScreen.Object, mockDrive.Object, mockPlayerInteraction.Object);

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
			Dictionary<int, string> mockDriveList = new Dictionary<int, string>()
			{
				[0] = "C:\\"
			};
			bool mockIsGameFilesExist = true;
			Mock<IInstallationUI> mockInstallationUI = new();
			mockInstallationUI
				.Setup(mockSetup => mockSetup.InstallationUIInitialize())
				.Verifiable();
			mockInstallationUI
				.Setup(mockSetup => mockSetup.DrivelistUI(mockDrivelistKey, mockDrivelistName))
				.Verifiable();
			Mock<IMainScreen> mockMainScreen = new();
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

			Installation installation = new(mockGameFile.Object, mockInstallationUI.Object, mockMainScreen.Object, mockDrive.Object, mockPlayerInteraction.Object);

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
			Dictionary<int, string> mockDriveList = new Dictionary<int, string>()
			{
				[0] = "C:\\"
			};
			bool mockIsGameFilesExist = true;
			Mock<IInstallationUI> mockInstallationUI = new();
			mockInstallationUI
				.Setup(mockSetup => mockSetup.InstallationUIInitialize())
				.Verifiable();
			mockInstallationUI
				.Setup(mockSetup => mockSetup.DrivelistUI(mockDrivelistKey, mockDrivelistName))
				.Verifiable();
			Mock<IMainScreen> mockMainScreen = new();
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
			Mock<IGameFile> mockGameFile = new();
			mockGameFile
				.Setup(mockSetup => mockSetup.CheckGameFilesCreated())
				.Returns(() => { return mockIsGameFilesExist; });

			Installation installation = new(mockGameFile.Object, mockInstallationUI.Object, mockMainScreen.Object, mockDrive.Object, mockPlayerInteraction.Object);

			installation.InstallationProcess();

			isInstallationSuccess = installation.IsInstallationSuccess;

			isInstallationSuccess.Should().BeFalse();
		}
	}
}
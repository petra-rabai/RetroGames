using NUnit.Framework;
using FluentAssertions;
using Moq;
using RetroGames;
using RetroGames.Games.DirectoryStructure;
using RetroGames.Person.Actions;
using System.Collections.Generic;

namespace RetroGamesTests
{
	public class DriveTests
	{
		
		[Test]
		public void CheckAvailableDriveCountNotZero()
		{
			char playerKey = '0';
			int testAvailableDriveCount = 0;
			
			
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });
			
			Drive  drive = new(playerInteraction.Object);
			
			drive.GetDriveList();

			testAvailableDriveCount = drive.AvailableDrives.Length;
		

			testAvailableDriveCount.Should().BePositive();
		}

		[Test]
		public void CheckAvailableDriveLoadingSuccess()
		{
			char playerKey = '0';
			string[] testAvailableDrives;

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Drive drive = new(playerInteraction.Object);
			drive.GetDriveInfo();
			testAvailableDrives = drive.CollectDrives();

			testAvailableDrives.Should().BeEquivalentTo(drive.AvailableDrives);
		}

		[Test]
		public void CheckDriveListCountNotZero()
		{
			char playerKey = '0';
			int testDriveListCount = 0;


			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Drive drive = new(playerInteraction.Object);

			drive.GetDriveList();

			testDriveListCount = drive.DriveList.Count;

			testDriveListCount.Should().BePositive();
		}

		[Test]
		public void CheckDriveListLoadingSuccess()
		{
			char playerKey = '0';
			Dictionary<int,string> testDriveList = new Dictionary<int, string>();

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Drive drive = new(playerInteraction.Object);

			testDriveList = drive.GetDriveList();

			testDriveList.Should().BeEquivalentTo(drive.DriveList);
		}


		[TestCase('0')]
		[TestCase('*')]
		[Test]
		public void CheckInstallationDriveNotNull(char testKey)
		{
			char playerKey = '0';
			string testInstallationDrive = "";
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Drive drive = new(playerInteraction.Object);

			drive.GetInstallationDrive(testKey);
			
			testInstallationDrive = drive.InstallationDrive;
			
			testInstallationDrive.Should().NotBeNullOrEmpty();

		}

		[Test]
		public void CheckIsInstallationDriveTrue()
		{
			char playerKey = '0';
			bool testIsInstallationDriveTrue = false;
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Drive drive = new(playerInteraction.Object);
			drive.GetDriveList();
			drive.DriveDecesion = playerKey;
			testIsInstallationDriveTrue = drive.InstallationDriveSelectionSuccess();

			testIsInstallationDriveTrue.Should().BeTrue();
		}

		[TestCase(true)]
		[Test]
		public void CheckIsInstallationDriveSuccess(bool testIsInstallationDrive)
		{
			char playerKey = '0';
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Drive drive = new(playerInteraction.Object);
			drive.GetDriveList();
			drive.DriveDecesion = playerKey;
			drive.InstallationDriveSelectionSuccess();

			testIsInstallationDrive.Should().Be(drive.IsInstallationDriveSelected);
		}

		[Test]
		public void CheckInstallationDriveEqualTheDefaultDrive()
		{
			char playerKey = '0';
			string[] testAvailableDrives = new string[1];
			string testDefaultDrive = "";

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Drive drive = new(playerInteraction.Object);
			
			testAvailableDrives[0] = "C:\\";
			drive.AvailableDrives = testAvailableDrives;

			drive.InstallationDriveSelectionSuccess();
			testDefaultDrive = drive.InstallationDrive;

			testDefaultDrive.Should().NotBeEmpty();

		}

		[Test]
		public void CheckDriveDecesionNotNull()
		{
			char playerKey = '0';
			char testDriveDecesion = ' ';
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Drive drive = new(playerInteraction.Object);
			
			testDriveDecesion = drive.GetDriveDecesionFromPlayer(playerKey);

			testDriveDecesion.Should().NotBeNull();
		}

		[Test]
		public void CheckDriveDecesionSuccess()
		{
			char playerKey = '0';
			char testDriveDecesion = ' ';
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Drive drive = new(playerInteraction.Object);

			testDriveDecesion = drive.GetDriveDecesionFromPlayer(playerKey);

			testDriveDecesion.Should().Be(drive.DriveDecesion);
		}

		[Test]
		public void CheckPlayerKeyNotNull()
		{
			char playerKey = '0';
			char testPlayerPressedKey = ' ';
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Drive drive = new(playerInteraction.Object);

			testPlayerPressedKey = drive.GetPlayerPressedKey();

			playerInteraction.Verify(mockVerify => mockVerify.GetPlayerKeyFromConsole(), Times.Once());

			testPlayerPressedKey.Should().NotBeNull();
		}

		[Test]
		public void CheckGetPlayerKeySuccess()
		{
			char playerKey = '0';
			char testPlayerKey = ' ';
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Drive drive = new(playerInteraction.Object);

			testPlayerKey = drive.GetPlayerPressedKey();

			playerInteraction.Verify(mockVerify => mockVerify.GetPlayerKeyFromConsole(), Times.Once());

			testPlayerKey.Should().Be(drive.PlayerPressedKey);
		}
	}
}
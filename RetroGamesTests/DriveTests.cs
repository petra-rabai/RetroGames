using FluentAssertions;
using Moq;
using NUnit.Framework;
using RetroGames.Game.DirectoryStructure;
using RetroGames.Person.Actions;
using System.Collections.Generic;
using System.IO.Abstractions;

namespace RetroGamesTests
{
	public class DriveTests
	{
		[Test]
		public void CheckAvailableDriveCountNotZero()
		{
			char mockPlayerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			drive.GetDriveList();

			int testAvailableDriveCount = drive.AvailableDrives.Length;

			testAvailableDriveCount.Should().BePositive();
		}

		[Test]
		public void CheckAvailableDriveLoadingSuccess()
		{
			char mockPlayerKey = '0';
			string[] testAvailableDrives;

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			drive.GetDriveInfo();
			testAvailableDrives = drive.CollectDrives();

			testAvailableDrives.Should().BeEquivalentTo(drive.AvailableDrives);
		}

		[Test]
		public void CheckDriveListCountNotZero()
		{
			char mockPlayerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			drive.GetDriveList();

			int testDriveListCount = drive.DriveList.Count;

			testDriveListCount.Should().BePositive();
		}

		[Test]
		public void CheckDriveListLoadingSuccess()
		{
			char mockPlayerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			Dictionary<int, string> testDriveList = drive.GetDriveList();

			testDriveList.Should().BeEquivalentTo(drive.DriveList);
		}

		[TestCase('0')]
		[TestCase('*')]
		[Test]
		public void CheckInstallationDriveNotNull(char testKey)
		{
			char mockPlayerKey = testKey;

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			drive.GetInstallationDrive();

			string testInstallationDrive = drive.InstallationDrive;

			testInstallationDrive.Should().NotBeNullOrEmpty();
		}

		[Test]
		public void CheckIsInstallationDriveTrue()
		{
			char mockPlayerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			drive.GetDriveList();
			drive.DriveDecision = mockPlayerKey;
			bool testIsInstallationDriveTrue = drive.InstallationDriveSelectionSuccess();

			testIsInstallationDriveTrue.Should().BeTrue();
		}

		[TestCase(true)]
		[Test]
		public void CheckIsInstallationDriveSuccess(bool testIsInstallationDrive)
		{
			char mockPlayerKey = '0';
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			drive.GetDriveList();
			drive.DriveDecision = mockPlayerKey;
			drive.InstallationDriveSelectionSuccess();

			testIsInstallationDrive.Should().Be(drive.IsInstallationDriveSelected);
		}

		[Test]
		public void CheckInstallationDriveEqualTheDefaultDrive()
		{
			char mockPlayerKey = '0';
			string[] testAvailableDrives = new string[1];

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			testAvailableDrives[0] = "C:\\";
			drive.AvailableDrives = testAvailableDrives;

			drive.InstallationDriveSelectionSuccess();
			string testDefaultDrive = drive.InstallationDrive;

			testDefaultDrive.Should().NotBeEmpty();
		}

		[Test]
		public void CheckInstallationDriveNotEqualTheDefaultDrive()
		{
			char mockPlayerKey = '0';
			string[] testAvailableDrives = new string[2];

			Dictionary<int, string> testDriveList = new()
			{
				[0] = "C:\\",
				[1] = "D:\\"
			};
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			testAvailableDrives[0] = "C:\\";
			testAvailableDrives[1] = "D:\\";

			drive.AvailableDrives = testAvailableDrives;
			drive.DriveDecision = mockPlayerKey;
			drive.DriveList = testDriveList;

			drive.InstallationDriveSelectionSuccess();

			string testDefaultDrive = drive.InstallationDrive;

			testDefaultDrive.Should().NotBeEmpty();
		}

		[TestCase(1)]
		[TestCase(2)]
		[Test]
		public void CheckCompareDiskSpace(int testDriveCount)
		{
			char mockPlayerKey = '0';
			long[] testAvailableFreeSpace;
			string[] testDriveName;
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			testAvailableFreeSpace = new long[testDriveCount];
			testDriveName = new string[testDriveCount];

			for (int i = 0; i < testDriveCount; i++)
			{
				if (testDriveCount > 1)
				{
					testAvailableFreeSpace[0] = 21474836480;
					testDriveName[0] = "C:\\";
					testAvailableFreeSpace[1] = 42949672960;
					testDriveName[1] = "D:\\";
				}
				else
				{
					testAvailableFreeSpace[0] = 21474836480;
					testDriveName[0] = "C:\\";
				}
			}

			string testDefaultDrive = drive.CompareDisksSpace(testDriveCount, testAvailableFreeSpace, testDriveName);

			testDefaultDrive.Should().NotBeEmpty();
		}

		[Test]
		public void CheckDriveDecesionNotNull()
		{
			char mockPlayerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			char testDriveDecesion = drive.GetDriveDecisionFromPlayer();

			testDriveDecesion.Should().NotBeNull();
		}

		[Test]
		public void CheckDriveDecesionSuccess()
		{
			char mockPlayerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			char testDriveDecesion = drive.GetDriveDecisionFromPlayer();

			testDriveDecesion.Should().Be(drive.DriveDecision);
		}

		[Test]
		public void CheckPlayerKeyNotNull()
		{
			char mockPlayerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			char testPlayerPressedKey = drive.GetPlayerPressedKey();

			playerInteraction.Verify(mockVerify => mockVerify.GetPlayerKeyFromConsole(), Times.Once());

			testPlayerPressedKey.Should().NotBeNull();
		}

		[Test]
		public void CheckGetPlayerKeySuccess()
		{
			char mockPlayerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			char testPlayerKey = drive.GetPlayerPressedKey();

			playerInteraction.Verify(mockVerify => mockVerify.GetPlayerKeyFromConsole(), Times.Once());

			testPlayerKey.Should().Be(drive.PlayerPressedKey);
		}
	}
}
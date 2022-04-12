using FluentAssertions;
using Moq;
using NUnit.Framework;
using RetroGames;
using RetroGames.Games.DirectoryStructure;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

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

			IFileSystem fileSystem = new FileSystem();
			
			Drive drive = new(playerInteraction.Object,fileSystem);

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

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

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

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			drive.GetDriveList();

			testDriveListCount = drive.DriveList.Count;

			testDriveListCount.Should().BePositive();
		}

		[Test]
		public void CheckDriveListLoadingSuccess()
		{
			char playerKey = '0';
			Dictionary<int, string> testDriveList = new Dictionary<int, string>();

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

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

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

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

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

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

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

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

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			testAvailableDrives[0] = "C:\\";
			drive.AvailableDrives = testAvailableDrives;

			drive.InstallationDriveSelectionSuccess();
			testDefaultDrive = drive.InstallationDrive;

			testDefaultDrive.Should().NotBeEmpty();
		}

		[Test]
		public void CheckInstallationDriveNotEqualTheDefaultDrive()
		{
			char playerKey = '0';
			string[] testAvailableDrives = new string[2];
			string testDefaultDrive = "";
			Dictionary<int, string> testDriveList = new()
			{
				[0] = "C:\\",
				[1] = "D:\\"
			};
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			IFileSystem fileSystem = new FileSystem();
			
			Drive drive = new(playerInteraction.Object, fileSystem);

			testAvailableDrives[0] = "C:\\";
			testAvailableDrives[1] = "D:\\";
			
			drive.AvailableDrives = testAvailableDrives;
			drive.DriveDecesion = playerKey;
			drive.DriveList = testDriveList;
			
			drive.InstallationDriveSelectionSuccess();
			
			testDefaultDrive = drive.InstallationDrive;

			testDefaultDrive.Should().NotBeEmpty();
		}

		[TestCase(1)]
		[TestCase(2)]
		[Test]
		public void CheckCompareDiskSpace(int testDriveCount)
		{
			char playerKey = '0';
			long[] testAvailableFreeSpace;
			string[] testDriveName;
			string testDefaultDrive = "";
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

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

			testDefaultDrive = drive.CompareDisksSpace(testDriveCount, testAvailableFreeSpace,testDriveName);

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

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

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

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

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

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

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

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction.Object, fileSystem);

			testPlayerKey = drive.GetPlayerPressedKey();

			playerInteraction.Verify(mockVerify => mockVerify.GetPlayerKeyFromConsole(), Times.Once());

			testPlayerKey.Should().Be(drive.PlayerPressedKey);
		}
	}
}
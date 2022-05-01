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
		public void CheckDriveListCountNotZero()
		{
			char mockPlayerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.ReadPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystemHelper fileSystemHelper = new FileSystemHelper();

			Drive drive = new(playerInteraction.Object, fileSystemHelper);

			drive.SetDriveList();

			int testDriveListCount = drive.DriveList.Count;

			testDriveListCount.Should().BePositive();
		}

		[Test]
		public void CheckDriveListLoadingSuccess()
		{
			char mockPlayerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.ReadPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystemHelper fileSystemHelper = new FileSystemHelper();

			Drive drive = new(playerInteraction.Object, fileSystemHelper);

			Dictionary<int, string> testDriveList = drive.SetDriveList();

			testDriveList.Should().BeEquivalentTo(drive.DriveList);
		}

		[TestCase('0')]
		[TestCase('*')]
		[Test]
		public void CheckInstallationDriveNotNull(char testKey)
		{
			char mockPlayerKey = testKey;
			int testDriveCount = 0;
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.ReadPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystemHelper fileSystemHelper = new FileSystemHelper();

			Drive drive = new(playerInteraction.Object, fileSystemHelper);
			
			drive.SetDriveDecisionFromPlayer();
			
			drive.SetInstallationDrive(testDriveCount);

			string testInstallationDrive = drive.InstallationDrive;

			testInstallationDrive.Should().NotBeNullOrEmpty();
		}

		[Test]
		public void CheckInstallationDriveEqualDefaultDrive()
		{
			char mockPlayerKey = '0';
			int testDriveCount = 1;

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.ReadPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			IFileSystemHelper fileSystemHelper = new FileSystemHelper();

			Drive drive = new(playerInteraction.Object, fileSystemHelper);
			
			drive.SetInstallationDrive(testDriveCount);

			string testInstallationDrive = drive.InstallationDrive;

			testInstallationDrive.Should().NotBeNullOrEmpty();
		}

	}
}
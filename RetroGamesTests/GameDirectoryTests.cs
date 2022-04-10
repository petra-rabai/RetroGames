using NUnit.Framework;
using FluentAssertions;
using Moq;
using RetroGames;
using RetroGames.Games.DirectoryStructure;
using RetroGames.Person.Actions;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

namespace RetroGamesTests
{
	public class GameDirectoryTests
	{
		[Test]
		public void CheckRetroGamesFolderCreated()
		{
			bool directoriesExist;


			

			

			char playerKey = '0';
			string testFolderPath = "";
			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });
			Mock<IFileSystem> fileSystem = new(MockBehavior.Strict);
			
			IFileSystemWatcher watcher = Mock.Of<IFileSystemWatcher>();
			
			IDirectory directory = Mock.Of<IDirectory>();

			Mock.Get(directory).Setup(folder => folder.Exists(It.IsAny<string>())).Returns(true);

			Drive drive = new(playerInteraction.Object);

			GameDirectory gameDirectory = new(drive,fileSystem.Object);

			gameDirectory.CheckGameDirectoriesExist();
			testFolderPath = gameDirectory.GameDirectoryPath;

			directoriesExist = gameDirectory.IsGameDirectoriesExist;
			
			Mock.Get(directory).Verify(folder => folder.Exists(It.IsAny<string>()), Times.Once);

			testFolderPath.Should().NotBeEmpty();
		}

		[Test]
		public void CheckGameDirectoryPathCreated()
		{
			string gameFolder;

			IPlayerInteraction playerInteraction = new PlayerInteraction();

			Drive drive = new(playerInteraction);
			GameDirectory gameDirectory = new(drive);

			gameDirectory.CheckGameDirectoriesExist();

			gameFolder = gameDirectory.GameDirectoryPath;

			Assert.IsNotNull(gameFolder);
		}

		[Test]
		public void CheckUserDirectoryPathCreated()
		{
			string userFolder;

			IPlayerInteraction playerInteraction = new PlayerInteraction();

			Drive drive = new(playerInteraction);
			GameDirectory gameDirectory = new(drive);

			gameDirectory.CheckGameDirectoriesExist();

			userFolder = gameDirectory.UserDirectoryPath;

			Assert.IsNotNull(userFolder);
		}

		[Test]
		public void CheckLogDirectoryPathCreated()
		{
			string logFolder;

			IPlayerInteraction playerInteraction = new PlayerInteraction();

			Drive drive = new(playerInteraction);
			GameDirectory gameDirectory = new(drive);

			gameDirectory.CheckGameDirectoriesExist();

			logFolder = gameDirectory.LogDirectoryPath;

			Assert.IsNotNull(logFolder);
		}

		[Test]
		public void CheckInstallationDriveExist()
		{
			string installationDrive;

			IPlayerInteraction playerInteraction = new PlayerInteraction();

			Drive drive = new(playerInteraction);
			GameDirectory gameDirectory = new(drive);
			gameDirectory.CheckGameDirectoriesExist();

			installationDrive = gameDirectory.InstallationDrive;

			Assert.IsNotNull(installationDrive);
		}

		[Test]
		public void CheckInstallationDriveExistSuccess()
		{
			bool installationDriveExist;

			IPlayerInteraction playerInteraction = new PlayerInteraction();

			Drive drive = new(playerInteraction);
			GameDirectory gameDirectory = new(drive);

			gameDirectory.CheckGameDirectoriesExist();

			installationDriveExist = gameDirectory.IsInstallationDriveSelected;

			Assert.IsTrue(installationDriveExist);
		}
	}
}
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RetroGames;
using RetroGames.Games.DirectoryStructure;
using RetroGames.Person.Actions;
using System;
using System.IO.Abstractions;

namespace RetroGamesTests
{
	public class GameDirectoryTests
	{
		[Test]
		public void CheckIsGameDriectoryDoesNotExist()
		{
			bool directoriesExist;

			char playerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Mock<IFileSystem> mockFileSystem = new();
			mockFileSystem.Setup(fileSystem => fileSystem.Directory.CreateDirectory(It.IsAny<String>())).Verifiable();

			mockFileSystem.Setup(fileSystem => fileSystem.Directory.Exists(It.IsAny<String>())).Returns(false);

			Drive drive = new(playerInteraction.Object, mockFileSystem.Object);

			GameDirectory gameDirectory = new(drive, mockFileSystem.Object);

			gameDirectory.CheckGameDirectoriesExist();

			directoriesExist = gameDirectory.IsGameDirectoriesExist;

			directoriesExist.Should().BeFalse();

			mockFileSystem.Verify(fileSystem => fileSystem.Directory.CreateDirectory(It.IsAny<String>()), Times.AtLeastOnce);
		}

		[Test]
		public void CheckIsGameDriectoryExist()
		{
			bool directoriesExist;

			char playerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Mock<IFileSystem> mockFileSystem = new();
			mockFileSystem.Setup(fileSystem => fileSystem.Directory.CreateDirectory(It.IsAny<String>())).Verifiable();
			mockFileSystem.Setup(fileSystem => fileSystem.Directory.Exists(It.IsAny<String>())).Returns(true);

			Drive drive = new(playerInteraction.Object, mockFileSystem.Object);

			GameDirectory gameDirectory = new(drive, mockFileSystem.Object);

			gameDirectory.CheckGameDirectoriesExist();

			directoriesExist = gameDirectory.IsGameDirectoriesExist;

			directoriesExist.Should().BeTrue();

			mockFileSystem.Verify(fileSystem => fileSystem.Directory.CreateDirectory(It.IsAny<String>()), Times.Never);
		}

		[Test]
		public void CheckGameDirectoryPathCreated()
		{
			string gameFolder;

			char playerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Mock<IFileSystem> mockFileSystem = new();
			mockFileSystem.Setup(fileSystem => fileSystem.Directory.CreateDirectory(It.IsAny<String>())).Verifiable();
			mockFileSystem.Setup(fileSystem => fileSystem.Directory.Exists(It.IsAny<String>())).Returns(false);

			Drive drive = new(playerInteraction.Object, mockFileSystem.Object);

			GameDirectory gameDirectory = new(drive, mockFileSystem.Object);

			gameDirectory.CheckGameDirectoriesExist();

			gameFolder = gameDirectory.GameDirectoryPath;

			gameFolder.Should().NotBeNull();

			mockFileSystem.Verify(fileSystem => fileSystem.Directory.CreateDirectory(It.IsAny<String>()));
		}

		[Test]
		public void CheckUserDirectoryPathCreated()
		{
			string userFolder;

			char playerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Mock<IFileSystem> mockFileSystem = new();
			mockFileSystem.Setup(fileSystem => fileSystem.Directory.CreateDirectory(It.IsAny<String>())).Verifiable();
			mockFileSystem.Setup(fileSystem => fileSystem.Directory.Exists(It.IsAny<String>())).Returns(false);

			Drive drive = new(playerInteraction.Object, mockFileSystem.Object);

			GameDirectory gameDirectory = new(drive, mockFileSystem.Object);

			gameDirectory.CheckGameDirectoriesExist();

			userFolder = gameDirectory.UserDirectoryPath;

			userFolder.Should().NotBeNull();

			mockFileSystem.Verify(fileSystem => fileSystem.Directory.CreateDirectory(It.IsAny<String>()));
		}

		[Test]
		public void CheckLogDirectoryPathCreated()
		{
			string logFolder;

			char playerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Mock<IFileSystem> mockFileSystem = new();
			mockFileSystem.Setup(fileSystem => fileSystem.Directory.CreateDirectory(It.IsAny<String>())).Verifiable();
			mockFileSystem.Setup(fileSystem => fileSystem.Directory.Exists(It.IsAny<String>())).Returns(false);

			Drive drive = new(playerInteraction.Object, mockFileSystem.Object);

			GameDirectory gameDirectory = new(drive, mockFileSystem.Object);

			gameDirectory.CheckGameDirectoriesExist();

			logFolder = gameDirectory.LogDirectoryPath;

			logFolder.Should().NotBeNull();

			mockFileSystem.Verify(fileSystem => fileSystem.Directory.CreateDirectory(It.IsAny<String>()));
		}

		[Test]
		public void CheckInstallationDriveExist()
		{
			string installationDrive;

			IPlayerInteraction playerInteraction = new PlayerInteraction();

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction, fileSystem);

			GameDirectory gameDirectory = new(drive, fileSystem);

			gameDirectory.CheckGameDirectoriesExist();

			installationDrive = gameDirectory.InstallationDrive;

			installationDrive.Should().NotBeNull();
		}

		[Test]
		public void CheckInstallationDriveExistSuccess()
		{
			bool installationDriveExist;

			IPlayerInteraction playerInteraction = new PlayerInteraction();

			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction, fileSystem);

			GameDirectory gameDirectory = new(drive, fileSystem);

			gameDirectory.CheckGameDirectoriesExist();

			installationDriveExist = gameDirectory.IsInstallationDriveSelected;

			installationDriveExist.Should().BeTrue();
		}
	}
}
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RetroGames;
using System;
using System.IO.Abstractions;
using RetroGames.Game.DirectoryStructure;
using RetroGames.Person.Actions;

namespace RetroGamesTests
{
	public class GameFileTests
	{
		[Test]
		public void CheckGameFilesDoesNotExistSuccess()
		{
			char playerKey = '0';
			bool testGameFilesExist;

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Mock<IFileSystem> mockFileSystem = new();
			mockFileSystem.Setup(fileSystem => fileSystem.File.Create(It.IsAny<String>())).Verifiable();

			mockFileSystem.Setup(fileSystem => fileSystem.File.Exists(It.IsAny<String>())).Returns(false);

			Drive drive = new(playerInteraction.Object, mockFileSystem.Object);

			GameDirectory gameDirectory = new(drive, mockFileSystem.Object);

			GameFile gameFile = new GameFile(drive, gameDirectory, mockFileSystem.Object);

			gameFile.CheckGameFilesCreated();

			testGameFilesExist = gameFile.IsGameFilesExist;

			testGameFilesExist.Should().BeFalse();

			mockFileSystem.Verify(fileSystem => fileSystem.File.Create(It.IsAny<String>()), Times.AtLeastOnce);
		}

		[Test]
		public void CheckGameFilesExistSuccess()
		{
			char playerKey = '0';
			bool testGameFilesExist;

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Mock<IFileSystem> mockFileSystem = new();
			mockFileSystem.Setup(fileSystem => fileSystem.File.Create(It.IsAny<String>())).Verifiable();

			mockFileSystem.Setup(fileSystem => fileSystem.File.Exists(It.IsAny<String>())).Returns(true);

			Drive drive = new(playerInteraction.Object, mockFileSystem.Object);

			GameDirectory gameDirectory = new(drive, mockFileSystem.Object);

			GameFile gameFile = new GameFile(drive, gameDirectory, mockFileSystem.Object);

			gameFile.CheckGameFilesCreated();

			testGameFilesExist = gameFile.IsGameFilesExist;

			testGameFilesExist.Should().BeTrue();

			mockFileSystem.Verify(fileSystem => fileSystem.File.Create(It.IsAny<String>()), Times.Never);
		}

		[Test]
		public void CheckGameFilePathCreated()
		{
			char playerKey = '0';
			string gameFilePath;

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Mock<IFileSystem> mockFileSystem = new();
			mockFileSystem.Setup(fileSystem => fileSystem.File.Create(It.IsAny<String>())).Verifiable();

			mockFileSystem.Setup(fileSystem => fileSystem.File.Exists(It.IsAny<String>())).Returns(false);

			Drive drive = new(playerInteraction.Object, mockFileSystem.Object);

			GameDirectory gameDirectory = new(drive, mockFileSystem.Object);

			GameFile gameFile = new GameFile(drive, gameDirectory, mockFileSystem.Object);

			gameFile.CheckGameFilesCreated();

			gameFilePath = gameFile.GameFilePath;

			gameFilePath.Should().NotBeNull();

			mockFileSystem.Verify(fileSystem => fileSystem.File.Exists(It.IsAny<String>()));
		}

		[Test]
		public void CheckUserFilePathCreated()
		{
			char playerKey = '0';
			string userFilePath;

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Mock<IFileSystem> mockFileSystem = new();
			mockFileSystem.Setup(fileSystem => fileSystem.File.Create(It.IsAny<String>())).Verifiable();

			mockFileSystem.Setup(fileSystem => fileSystem.File.Exists(It.IsAny<String>())).Returns(false);

			Drive drive = new(playerInteraction.Object, mockFileSystem.Object);

			GameDirectory gameDirectory = new(drive, mockFileSystem.Object);

			GameFile gameFile = new GameFile(drive, gameDirectory, mockFileSystem.Object);

			gameFile.CheckGameFilesCreated();

			userFilePath = gameFile.GameFilePath;

			userFilePath.Should().NotBeNull();

			mockFileSystem.Verify(fileSystem => fileSystem.File.Exists(It.IsAny<String>()));
		}

		[Test]
		public void CheckLogFilePathCreated()
		{
			string logFilePath;
			char playerKey = '0';

			Mock<IPlayerInteraction> playerInteraction = new(MockBehavior.Strict);
			playerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return playerKey; });

			Mock<IFileSystem> mockFileSystem = new();
			mockFileSystem.Setup(fileSystem => fileSystem.File.Create(It.IsAny<String>())).Verifiable();

			mockFileSystem.Setup(fileSystem => fileSystem.File.Exists(It.IsAny<String>())).Returns(false);

			Drive drive = new(playerInteraction.Object, mockFileSystem.Object);

			GameDirectory gameDirectory = new(drive, mockFileSystem.Object);

			GameFile gameFile = new GameFile(drive, gameDirectory, mockFileSystem.Object);

			gameFile.CheckGameFilesCreated();

			logFilePath = gameFile.GameFilePath;

			logFilePath.Should().NotBeNull();

			mockFileSystem.Verify(fileSystem => fileSystem.File.Exists(It.IsAny<String>()));
		}
	}
}
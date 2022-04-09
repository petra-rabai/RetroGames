using NUnit.Framework;
using RetroGames;
using RetroGames.Games.DirectoryStructure;
using RetroGames.Person.Actions;
using System.IO.Abstractions;

namespace RetroGamesTests
{
	public class GameFileTests
	{
		[Test]
		public void CheckGameFilesExistSuccess()
		{
			bool gameFilesExist;

			IPlayerInteraction playerInteraction = new PlayerInteraction();

			Drive drive = new Drive(playerInteraction);
			GameDirectory gameDirectory = new GameDirectory(drive);

			GameFile gameFile = new GameFile(drive, gameDirectory);

			gameFile.CheckGameFilesCreated();

			gameFilesExist = gameFile.IsGameFilesExist;

			Assert.IsTrue(gameFilesExist);
		}

		[Test]
		public void CheckGameFilePathCreated()
		{
			string gameFilePath;

			IPlayerInteraction playerInteraction = new PlayerInteraction();
			IFileSystem fileSystem = new FileSystem();

			Drive drive = new Drive(playerInteraction);
			GameDirectory gameDirectory = new GameDirectory(drive);

			GameFile gameFile = new GameFile(drive, gameDirectory);

			gameFile.CheckGameFilesCreated();

			gameFilePath = gameFile.GameFilePath;

			Assert.IsNotNull(gameFilePath);
		}

		[Test]
		public void CheckUserFilePathCreated()
		{
			string userFilePath;

			IPlayerInteraction playerInteraction = new PlayerInteraction();
			IFileSystem fileSystem = new FileSystem();

			Drive drive = new Drive(playerInteraction);
			GameDirectory gameDirectory = new GameDirectory(drive);

			GameFile gameFile = new GameFile(drive, gameDirectory);

			gameFile.CheckGameFilesCreated();

			userFilePath = gameFile.UserFilePath;

			Assert.IsNotNull(userFilePath);
		}

		[Test]
		public void CheckLogFilePathCreated()
		{
			string logFilePath;

			IPlayerInteraction playerInteraction = new PlayerInteraction();
			IFileSystem fileSystem = new FileSystem();

			Drive drive = new Drive(playerInteraction);
			GameDirectory gameDirectory = new GameDirectory(drive);

			GameFile gameFile = new GameFile(drive, gameDirectory);

			gameFile.CheckGameFilesCreated();

			logFilePath = gameFile.LogFilePath;

			Assert.IsNotNull(logFilePath);
		}
	}
}
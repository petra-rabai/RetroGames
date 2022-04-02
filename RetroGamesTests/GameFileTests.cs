using NUnit.Framework;
using RetroGames;
using System.IO;

namespace RetroGamesTests
{
	public class GameFileTests
	{
		[Test]
		public void CheckGameFilesExistSuccess()
		{
			bool gameFilesExist;

			GameFile gameFile = new GameFile();
			Drive drive = new Drive();
			GameDirectory gameDirectory = new GameDirectory();

			gameFile.CheckGameFilesCreated(drive,gameDirectory);

			gameFilesExist = gameFile.IsGameFilesExist;
			
			Assert.IsTrue(gameFilesExist);

		}

		[Test]
		public void CheckGameFilePathCreated()
		{
			string gameFilePath;

			GameFile gameFile = new GameFile();
			Drive drive = new Drive();
			GameDirectory gameDirectory = new GameDirectory();

			gameFile.CheckGameFilesCreated(drive, gameDirectory);

			gameFilePath = gameFile.GameFilePath;
			
			Assert.IsNotNull(gameFilePath);
		}

		[Test]
		public void CheckUserFilePathCreated()
		{
			string userFilePath;

			GameFile gameFile = new GameFile();
			Drive drive = new Drive();
			GameDirectory gameDirectory = new GameDirectory();

			gameFile.CheckGameFilesCreated(drive,gameDirectory);

			userFilePath = gameFile.UserFilePath;

			Assert.IsNotNull(userFilePath);
		}

		[Test]
		public void CheckLogFilePathCreated()
		{
			string logFilePath;

			GameFile gameFile = new GameFile();
			Drive drive = new Drive();
			GameDirectory gameDirectory = new GameDirectory();

			gameFile.CheckGameFilesCreated(drive,gameDirectory);

			logFilePath = gameFile.LogFilePath;

			Assert.IsNotNull(logFilePath);
		}

	}
}

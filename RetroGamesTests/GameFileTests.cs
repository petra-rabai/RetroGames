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

			gameFile.CheckGameFilesCreated();

			gameFilesExist = gameFile.IsGameFilesExist;
			
			Assert.IsTrue(gameFilesExist);

		}

		[Test]
		public void CheckGameFilePathCreated()
		{
			string gameFilePath;

			GameFile gameFile = new GameFile();
			
			gameFile.CheckGameFilesCreated();

			gameFilePath = gameFile.GameFilePath;
			
			Assert.IsNotNull(gameFilePath);
		}

		[Test]
		public void CheckUserFilePathCreated()
		{
			string userFilePath;

			GameFile gameFile = new GameFile();

			gameFile.CheckGameFilesCreated();

			userFilePath = gameFile.UserFilePath;

			Assert.IsNotNull(userFilePath);
		}

		[Test]
		public void CheckLogFilePathCreated()
		{
			string logFilePath;

			GameFile gameFile = new GameFile();

			gameFile.CheckGameFilesCreated();

			logFilePath = gameFile.LogFilePath;

			Assert.IsNotNull(logFilePath);
		}

	}
}

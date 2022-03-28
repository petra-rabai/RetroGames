using NUnit.Framework;
using RetroGames;

namespace RetroGamesTests
{
	public class GameDirectoryTests
	{

		[Test]
		public void CheckGameDirectoriesExistSuccess()
		{
			bool directoriesExist;

			GameDirectory gameDirectory = new GameDirectory();
			
			gameDirectory.CheckGameDirectoriesExist();

			directoriesExist = gameDirectory.IsGameDirectoriesExist;

			Assert.IsTrue(directoriesExist);
		}

		[Test]
		public void CheckGameDirectoryPathExist()
		{
			string gameFolder;
			
			GameDirectory gameDirectory = new GameDirectory();

			gameDirectory.CheckGameDirectoriesExist();

			gameFolder = gameDirectory.GameDirectoryPath;

			Assert.IsNotNull(gameFolder);
		}

		[Test]
		public void CheckUserDirectoryPathExist()
		{
			string userFolder;
			
			GameDirectory gameDirectory = new GameDirectory();

			gameDirectory.CheckGameDirectoriesExist();

			userFolder = gameDirectory.UserDirectoryPath;
			
			Assert.IsNotNull(userFolder);
		}

		[Test]
		public void CheckLogDirectoryPathExist()
		{
			string logFolder;

			GameDirectory gameDirectory = new GameDirectory();

			gameDirectory.CheckGameDirectoriesExist();

			logFolder = gameDirectory.LogDirectoryPath;

			Assert.IsNotNull(logFolder);
		}

		[Test]
		public void CheckInstallationDriveExist()
		{
			string installationDrive;

			GameDirectory gameDirectory = new GameDirectory();

			gameDirectory.CheckGameDirectoriesExist();

			installationDrive = gameDirectory.InstallationDrive;

			Assert.IsNotNull(installationDrive);

		}

		[Test]
		public void CheckInstallationDriveExistSuccess()
		{
			bool installationDriveExist;
			
			GameDirectory gameDirectory = new GameDirectory();

			gameDirectory.CheckGameDirectoriesExist();

			installationDriveExist = gameDirectory.IsInstallationDriveSelected;

			Assert.IsTrue(installationDriveExist);
		}

	}
}

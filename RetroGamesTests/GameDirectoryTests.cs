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
			Drive drive = new Drive();
			
			gameDirectory.CheckGameDirectoriesExist(drive);

			directoriesExist = gameDirectory.IsGameDirectoriesExist;

			Assert.IsTrue(directoriesExist);
		}

		[Test]
		public void CheckGameDirectoryPathCreated()
		{
			string gameFolder;
			
			GameDirectory gameDirectory = new GameDirectory();
			Drive drive = new Drive();

			gameDirectory.CheckGameDirectoriesExist(drive);

			gameFolder = gameDirectory.GameDirectoryPath;

			Assert.IsNotNull(gameFolder);
		}

		[Test]
		public void CheckUserDirectoryPathCreated()
		{
			string userFolder;
			
			GameDirectory gameDirectory = new GameDirectory();
			Drive drive = new Drive();

			gameDirectory.CheckGameDirectoriesExist(drive);

			userFolder = gameDirectory.UserDirectoryPath;
			
			Assert.IsNotNull(userFolder);
		}

		[Test]
		public void CheckLogDirectoryPathCreated()
		{
			string logFolder;

			GameDirectory gameDirectory = new GameDirectory();
			Drive drive = new Drive();

			gameDirectory.CheckGameDirectoriesExist(drive);

			logFolder = gameDirectory.LogDirectoryPath;

			Assert.IsNotNull(logFolder);
		}

		[Test]
		public void CheckInstallationDriveExist()
		{
			string installationDrive;

			GameDirectory gameDirectory = new GameDirectory();
			Drive drive = new Drive();

			gameDirectory.CheckGameDirectoriesExist(drive);

			installationDrive = gameDirectory.InstallationDrive;

			Assert.IsNotNull(installationDrive);

		}

		[Test]
		public void CheckInstallationDriveExistSuccess()
		{
			bool installationDriveExist;
			
			GameDirectory gameDirectory = new GameDirectory();
			Drive drive = new Drive();

			gameDirectory.CheckGameDirectoriesExist(drive);

			installationDriveExist = gameDirectory.IsInstallationDriveSelected;

			Assert.IsTrue(installationDriveExist);
		}

	}
}

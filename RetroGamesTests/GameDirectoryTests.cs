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

			IPlayerInteraction playerInteraction = new PlayerInteraction();

			Drive drive = new(playerInteraction);
			GameDirectory gameDirectory = new(drive);

			gameDirectory.CheckGameDirectoriesExist();

			directoriesExist = gameDirectory.IsGameDirectoriesExist;

			Assert.IsTrue(directoriesExist);
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
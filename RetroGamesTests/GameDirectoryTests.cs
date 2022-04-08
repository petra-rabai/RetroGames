using NUnit.Framework;
using RetroGames;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

namespace RetroGamesTests
{
	public class GameDirectoryTests
	{

		[Test]
		public void CheckGameDirectoriesExistSuccess()
		{
			bool directoriesExist;
			
			IPlayerInteraction playerInteraction = new PlayerInteraction();
			IFileSystem fileSystem = new FileSystem();
			
			Drive drive = new(playerInteraction);
			GameDirectory gameDirectory = new(drive, fileSystem);
			
			gameDirectory.CheckGameDirectoriesExist();

			directoriesExist = gameDirectory.IsGameDirectoriesExist;

			Assert.IsTrue(directoriesExist);
		}

		[Test]
		public void CheckGameDirectoryPathCreated()
		{
			string gameFolder;

			IPlayerInteraction playerInteraction = new PlayerInteraction();
			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction);
			GameDirectory gameDirectory = new(drive, fileSystem);

			gameDirectory.CheckGameDirectoriesExist();

			gameFolder = gameDirectory.GameDirectoryPath;

			Assert.IsNotNull(gameFolder);
		}

		[Test]
		public void CheckUserDirectoryPathCreated()
		{
			string userFolder;

			IPlayerInteraction playerInteraction = new PlayerInteraction();
			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction);
			GameDirectory gameDirectory = new(drive, fileSystem);

			gameDirectory.CheckGameDirectoriesExist();

			userFolder = gameDirectory.UserDirectoryPath;
			
			Assert.IsNotNull(userFolder);
		}

		[Test]
		public void CheckLogDirectoryPathCreated()
		{
			string logFolder;

			IPlayerInteraction playerInteraction = new PlayerInteraction();
			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction);
			GameDirectory gameDirectory = new(drive, fileSystem);

			gameDirectory.CheckGameDirectoriesExist();

			logFolder = gameDirectory.LogDirectoryPath;

			Assert.IsNotNull(logFolder);
		}

		[Test]
		public void CheckInstallationDriveExist()
		{
			string installationDrive;

			IPlayerInteraction playerInteraction = new PlayerInteraction();
			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction);
			GameDirectory gameDirectory = new(drive, fileSystem);
			gameDirectory.CheckGameDirectoriesExist();

			installationDrive = gameDirectory.InstallationDrive;

			Assert.IsNotNull(installationDrive);

		}

		[Test]
		public void CheckInstallationDriveExistSuccess()
		{
			bool installationDriveExist;

			IPlayerInteraction playerInteraction = new PlayerInteraction();
			IFileSystem fileSystem = new FileSystem();

			Drive drive = new(playerInteraction);
			GameDirectory gameDirectory = new(drive, fileSystem);

			gameDirectory.CheckGameDirectoriesExist();

			installationDriveExist = gameDirectory.IsInstallationDriveSelected;

			Assert.IsTrue(installationDriveExist);
		}

	}
}

using RetroGames.Properties;
using System.IO;

namespace RetroGames
{
	public class GameDirectory : IGameDirectory
	{
		private IDrive drive;

		public GameDirectory(IDrive drive)
		{
			this.drive = drive;
		}

		public string InstallationDrive { get; set; }
		public bool IsInstallationDriveSelected { get; set; }
		public bool IsGameDirectoriesExist { get; set; }
		public string GameDirectoryPath { get; set; }
		public string UserDirectoryPath { get; set; }
		public string LogDirectoryPath { get; set; }

		public bool CheckGameDirectoriesExist()
		{
			GetInstallationDrive();

			GameDirectoryPath = InstallationDrive + GameSettings.Default.GameDirectory;
			UserDirectoryPath = InstallationDrive + GameSettings.Default.UserDirectory;
			LogDirectoryPath = InstallationDrive + GameSettings.Default.LogDirectory;

			if (!Directory.Exists(GameDirectoryPath) && !Directory.Exists(UserDirectoryPath) && !Directory.Exists(LogDirectoryPath))
			{
				IsGameDirectoriesExist = false;

				CreateGameDirectories();
			}
			else
			{
				IsGameDirectoriesExist = true;
			}

			return IsGameDirectoriesExist;
		}

		private void CreateGameDirectories()
		{
			CreateGameDirectory();
			CreateUserDirectory();
			CreateLogDirectory();
		}

		private string CreateGameDirectory()
		{
			GameDirectoryPath = InstallationDrive + GameSettings.Default.GameDirectory;

			Directory.CreateDirectory(GameDirectoryPath);

			return GameDirectoryPath;
		}

		private string GetInstallationDrive()
		{
			drive.GetInstallationDrive(drive.PlayerPressedKey);

			InstallationDrive = drive.InstallationDrive;

			IsInstallationDriveSelected = drive.IsInstallationDriveSelected;

			return InstallationDrive;
		}

		private string CreateUserDirectory()
		{
			UserDirectoryPath = InstallationDrive + GameSettings.Default.UserDirectory;

			Directory.CreateDirectory(UserDirectoryPath);

			return UserDirectoryPath;
		}

		private string CreateLogDirectory()
		{
			LogDirectoryPath = InstallationDrive + GameSettings.Default.LogDirectory;

			Directory.CreateDirectory(LogDirectoryPath);

			return LogDirectoryPath;
		}
	}
}
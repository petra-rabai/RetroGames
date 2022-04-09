using RetroGames.Properties;
using System.IO;

namespace RetroGames.Games.DirectoryStructure
{
	public class GameDirectory : IGameDirectory
	{
		private IDrive _drive;

		public GameDirectory(IDrive drive)
		{
			_drive = drive;
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
			_drive.GetInstallationDrive(_drive.PlayerPressedKey);

			InstallationDrive = _drive.InstallationDrive;

			IsInstallationDriveSelected = _drive.IsInstallationDriveSelected;

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
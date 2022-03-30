using RetroGames.Properties;
using System.IO;

namespace RetroGames
{
	public class GameDirectory : IDrive, IGameDirectory
	{
		public string InstallationDrive { get; set; }
		public bool IsInstallationDriveSelected { get; set; }
		Drive Drive { get; set; } = new Drive();
		public bool IsGameDirectoriesExist { get; set; }
		public string GameDirectoryPath { get; set; }
		public string UserDirectoryPath { get; set; }
		public string LogDirectoryPath { get; set; }
		
		public bool CheckGameDirectoriesExist()
		{
			CreateGameDirectories();

			if (!Directory.Exists(GameDirectoryPath) && !Directory.Exists(UserDirectoryPath) && !Directory.Exists(LogDirectoryPath))
			{
				IsGameDirectoriesExist = false;
			}
			else
			{
				IsGameDirectoriesExist = true;
			}

			return IsGameDirectoriesExist;
		}

		private void CreateGameDirectories()
		{
			GetInstallationDrive();
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
			InstallationDrive = Drive.SelectInstallationDrive();

			IsInstallationDriveSelected = Drive.IsInstallationDriveSelected;

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

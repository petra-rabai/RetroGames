using RetroGames.Properties;
using System.IO;
using System.IO.Abstractions;

namespace RetroGames
{
	public class GameDirectory : IGameDirectory
	{
		private IDrive drive;

		readonly IFileSystem fileSystem;
		
		public GameDirectory(IDrive drive, IFileSystem fileSystem)
		{
			this.drive = drive;
			this.fileSystem = fileSystem;
		}
		public string InstallationDrive { get; set; }
		public bool IsInstallationDriveSelected { get; set; }
		public bool IsGameDirectoriesExist { get; set; }
		public string GameDirectoryPath { get; set; }
		public string UserDirectoryPath { get; set; }
		public string LogDirectoryPath { get; set; }
		
		public bool CheckGameDirectoriesExist()
		{
			
			
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

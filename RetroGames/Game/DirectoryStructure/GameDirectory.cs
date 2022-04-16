using System.IO.Abstractions;
using RetroGames.Properties;

namespace RetroGames.Game.DirectoryStructure
{
	public class GameDirectory : IGameDirectory
	{
		private readonly IDrive _drive;
		private readonly IFileSystem _fileSystem;

		public GameDirectory(IDrive drive, IFileSystem fileSystem)
		{
			_drive = drive;
			_fileSystem = fileSystem;
		}

		public string InstallationDrive { get; set; }
		public bool IsInstallationDriveSelected { get; set; }
		public bool IsGameDirectoriesExist { get; set; }
		public string GameDirectoryPath { get; set; }
		public string UserDirectoryPath { get; set; }
		public string LogDirectoryPath { get; set; }

		public bool CheckGameDirectoriesExist()
		{
			InstallationDrive = GetInstallationDrive();

			GameDirectoryPath = InstallationDrive + GameSettings.Default.GameDirectory;
			UserDirectoryPath = InstallationDrive + GameSettings.Default.UserDirectory;
			LogDirectoryPath = InstallationDrive + GameSettings.Default.LogDirectory;

			if (!_fileSystem.Directory.Exists(GameDirectoryPath) && !_fileSystem.Directory.Exists(UserDirectoryPath) && !_fileSystem.Directory.Exists(LogDirectoryPath))
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

		private string GetInstallationDrive()
		{
			_drive.GetInstallationDrive();

			InstallationDrive = _drive.InstallationDrive;

			IsInstallationDriveSelected = _drive.IsInstallationDriveSelected;

			return InstallationDrive;
		}

		public void CreateGameDirectories()
		{
			GameDirectoryPath = CreateGameDirectory();

			UserDirectoryPath = CreateUserDirectory();

			LogDirectoryPath = CreateLogDirectory();
		}

		private string CreateGameDirectory()
		{
			GameDirectoryPath = InstallationDrive + GameSettings.Default.GameDirectory;

			_fileSystem.Directory.CreateDirectory(GameDirectoryPath);

			return GameDirectoryPath;
		}

		private string CreateUserDirectory()
		{
			UserDirectoryPath = InstallationDrive + GameSettings.Default.UserDirectory;
			
			_fileSystem.Directory.CreateDirectory(UserDirectoryPath);

			return UserDirectoryPath;
		}

		private string CreateLogDirectory()
		{
			LogDirectoryPath = InstallationDrive + GameSettings.Default.LogDirectory;

			_fileSystem.Directory.CreateDirectory(LogDirectoryPath);

			return LogDirectoryPath;
		}
	}
}
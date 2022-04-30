using RetroGames.Properties;
using System.IO.Abstractions;

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

		private string _installationDrive;
		public bool IsGameDirectoriesExist { get; set; }
		public string GameDirectoryPath { get; set; }
		public string UserDirectoryPath { get; set; }
		public string LogDirectoryPath { get; set; }

		public bool CheckGameDirectoriesExist()
		{
			_installationDrive = SelectInstallationDrive();

			GameDirectoryPath = _installationDrive + GameSettings.Default.GameDirectory;
			UserDirectoryPath = _installationDrive + GameSettings.Default.UserDirectory;
			LogDirectoryPath = _installationDrive + GameSettings.Default.LogDirectory;

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

		private string SelectInstallationDrive()
		{
			_installationDrive = _drive.SetInstallationDrive(0);

			return _installationDrive;
		}

		private void CreateGameDirectories()
		{
			GameDirectoryPath = CreateGameDirectory();

			UserDirectoryPath = CreateUserDirectory();

			LogDirectoryPath = CreateLogDirectory();
		}

		private string CreateGameDirectory()
		{
			_fileSystem.Directory.CreateDirectory(GameDirectoryPath);

			return GameDirectoryPath;
		}

		private string CreateUserDirectory()
		{
			_fileSystem.Directory.CreateDirectory(UserDirectoryPath);

			return UserDirectoryPath;
		}

		private string CreateLogDirectory()
		{
			_fileSystem.Directory.CreateDirectory(LogDirectoryPath);

			return LogDirectoryPath;
		}
	}
}
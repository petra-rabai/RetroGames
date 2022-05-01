using RetroGames.Game.Structure;
using RetroGames.Game.Structure.Hdd;
using RetroGames.Properties;
using System.IO.Abstractions;

namespace RetroGames.Game.DirectoryStructure
{
	public class GameDirectory : IGameDirectory
	{
		private readonly IInstallationHdd _installationHdd;
		private readonly IFileSystemHelper _fileSystemHelper;

		public GameDirectory(IInstallationHdd installationHdd, IFileSystemHelper fileSystemHelper)
		{
			_installationHdd = installationHdd;
			_fileSystemHelper = fileSystemHelper;
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

			if (!_fileSystemHelper.FileSystem.Directory.Exists(GameDirectoryPath) && !_fileSystemHelper.FileSystem.Directory.Exists(UserDirectoryPath) && !_fileSystemHelper.FileSystem.Directory.Exists(LogDirectoryPath))
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
			_installationHdd.GetInstallationHddName();

			_installationDrive = _installationHdd.HddName;

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
			_fileSystemHelper.FileSystem.Directory.CreateDirectory(GameDirectoryPath);

			return GameDirectoryPath;
		}

		private string CreateUserDirectory()
		{
			_fileSystemHelper.FileSystem.Directory.CreateDirectory(UserDirectoryPath);

			return UserDirectoryPath;
		}

		private string CreateLogDirectory()
		{
			_fileSystemHelper.FileSystem.Directory.CreateDirectory(LogDirectoryPath);

			return LogDirectoryPath;
		}
	}
}
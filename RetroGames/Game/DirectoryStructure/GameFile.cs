using System.IO.Abstractions;
using RetroGames.Properties;

namespace RetroGames.Game.DirectoryStructure
{
	public class GameFile : IGameFile
	{
		private readonly IGameDirectory _gameDirectory;
		private readonly IDrive _drive;
		private readonly IFileSystem _fileSystem;

		public GameFile(IDrive drive, IGameDirectory gameDirectory, IFileSystem fileSystem)
		{
			_drive = drive;
			_gameDirectory = gameDirectory;
			_fileSystem = fileSystem;
		}

		public string GameDirectoryPath { get; set; }
		public bool IsGameFilesExist { get; set; }
		public string GameFilePath { get; set; }
		public string UserFilePath { get; set; }
		public string LogFilePath { get; set; }
		public string UserDirectoryPath { get; set; }
		public string LogDirectoryPath { get; set; }

		private string _installationDrive;

		public bool CheckGameFilesCreated()
		{
			_installationDrive = GetInstallationDrive();

			UserFilePath = _installationDrive + GameSettings.Default.UserDirectory + GameSettings.Default.UserFile;
			LogFilePath = _installationDrive + GameSettings.Default.LogDirectory + GameSettings.Default.LogFile;
			GameFilePath = _installationDrive + GameSettings.Default.GameDirectory + GameSettings.Default.GameFile;

			if (!_fileSystem.File.Exists(UserFilePath) && !_fileSystem.File.Exists(GameFilePath) && !_fileSystem.File.Exists(LogFilePath))
			{
				CreateGameFiles();
			}
			else
			{
				IsGameFilesExist = true;
			}

			return IsGameFilesExist;
		}

		private string GetInstallationDrive()
		{
			_drive.GetInstallationDrive();

			_installationDrive = _drive.InstallationDrive;
			
			return _installationDrive;
		}

		public void CreateGameFiles()
		{
			GameFilePath = CreateGameFile();

			UserFilePath = CreateUserFile();

			LogFilePath = CreateLogFile();
		}

		private string CreateGameFile()
		{
			GameDirectoryPath = _gameDirectory.GameDirectoryPath;
			
			GameFilePath = GameDirectoryPath + GameSettings.Default.GameFile;

			_fileSystem.File.Create(GameFilePath);
			
			return GameFilePath;
		}

		private string CreateUserFile()
		{
			UserDirectoryPath = _gameDirectory.UserDirectoryPath;
			
			UserFilePath = UserDirectoryPath + GameSettings.Default.UserFile;

			_fileSystem.File.Create(UserFilePath);

			return UserFilePath;
		}

		private string CreateLogFile()
		{
			LogDirectoryPath = _gameDirectory.LogDirectoryPath;
			
			LogFilePath = LogDirectoryPath + GameSettings.Default.LogFile;

			_fileSystem.File.Create(LogFilePath);

			return LogFilePath;
		}
	}
}
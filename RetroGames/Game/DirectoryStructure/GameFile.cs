using RetroGames.Properties;
using System.IO.Abstractions;

namespace RetroGames.Games.DirectoryStructure
{
	public class GameFile : IGameFile
	{
		private IGameDirectory _gameDirectory;
		private IDrive _drive;
		private IFileSystem _fileSystem;

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

		public bool CheckGameFilesCreated()
		{
			_drive.GetInstallationDrive(' ');
			UserFilePath = _drive.InstallationDrive + GameSettings.Default.UserDirectory + GameSettings.Default.UserFile;
			LogFilePath = _drive.InstallationDrive + GameSettings.Default.LogDirectory + GameSettings.Default.LogFile;
			GameFilePath = _drive.InstallationDrive + GameSettings.Default.GameDirectory + GameSettings.Default.GameFile;

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

		public void CreateGameFiles()
		{
			CreateGameFile();
			CreateUserFile();
			CreateLogFile();
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
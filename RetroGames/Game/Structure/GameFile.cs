using RetroGames.Properties;
using Serilog;
using System.IO.Abstractions;

namespace RetroGames.Game.DirectoryStructure
{
	public class GameFile : IGameFile
	{
		private readonly IGameDirectory _gameDirectory;
		private readonly IFileSystemHelper _fileSystemHelper;

		public GameFile(IGameDirectory gameDirectory, IFileSystemHelper fileSystemHelper)
		{
			_gameDirectory = gameDirectory;
			_fileSystemHelper = fileSystemHelper;
		}

		public bool IsGameFilesExist { get; set; }
		public string GameFilePath { get; set; }
		public string UserFilePath { get; set; }
		public string LogFilePath { get; set; }
				
		public bool CheckGameFilesCreated()
		{
			_gameDirectory.CheckGameDirectoriesExist();

			UserFilePath = _gameDirectory.UserDirectoryPath + GameSettings.Default.UserFile;
			LogFilePath = _gameDirectory.LogDirectoryPath + GameSettings.Default.LogFile;
			GameFilePath = _gameDirectory.GameDirectoryPath + GameSettings.Default.GameFile;

			if (!_fileSystemHelper.FileSystem.File.Exists(UserFilePath) && !_fileSystemHelper.FileSystem.File.Exists(GameFilePath) && !_fileSystemHelper.FileSystem.File.Exists(LogFilePath))
			{
				CreateGameFiles();
			}
			else
			{
				IsGameFilesExist = true;
			}

			return IsGameFilesExist;
		}

		private void CreateGameFiles()
		{
			GameFilePath = CreateGameFile();

			UserFilePath = CreateUserFile();

			LogFilePath = CreateLogFile();
		}

		private string CreateGameFile()
		{
			_fileSystemHelper.FileSystem.File.Create(GameFilePath);

			return GameFilePath;
		}

		private string CreateUserFile()
		{
			_fileSystemHelper.FileSystem.File.Create(UserFilePath);

			return UserFilePath;
		}

		private string CreateLogFile()
		{
			_fileSystemHelper.FileSystem.File.Create(LogFilePath);

			return LogFilePath;
		}
	}
}
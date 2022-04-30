using RetroGames.Properties;
using Serilog;
using System.IO.Abstractions;

namespace RetroGames.Game.DirectoryStructure
{
	public class GameFile : IGameFile
	{
		private readonly IGameDirectory _gameDirectory;
		private readonly IFileSystem _fileSystem;

		public GameFile(IGameDirectory gameDirectory, IFileSystem fileSystem)
		{
			_gameDirectory = gameDirectory;
			_fileSystem = fileSystem;
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

		private void CreateGameFiles()
		{
			GameFilePath = CreateGameFile();

			UserFilePath = CreateUserFile();

			LogFilePath = CreateLogFile();
		}

		private string CreateGameFile()
		{
			_fileSystem.File.Create(GameFilePath);

			return GameFilePath;
		}

		private string CreateUserFile()
		{
			_fileSystem.File.Create(UserFilePath);

			return UserFilePath;
		}

		private string CreateLogFile()
		{
			_fileSystem.File.Create(LogFilePath);

			return LogFilePath;
		}
	}
}
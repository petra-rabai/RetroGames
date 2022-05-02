using RetroGames.Game.Structure.Folders;
using RetroGames.Game.Structure.Helper;
using RetroGames.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Game.Structure.Files
{
	public class GameFile : IGameFile
	{
		private readonly IGameFolder _gameFolder;
		private readonly IFileSystemHelper _fileSystemHelper;

		public GameFile(IGameFolder gameFolder, IFileSystemHelper fileSystemHelper)
		{
			_gameFolder = gameFolder;
			_fileSystemHelper = fileSystemHelper;
		}

		private string _filePath;

		public string GameFilePath { get; set; }

		public void CreateGameFile()
		{
			_gameFolder.CreateGameFolder();
			_filePath = _gameFolder.GameFolderPath + GameSettings.Default.GameFile;

			if (!_fileSystemHelper.FileSystem.File.Exists(_filePath))
			{
				GameFilePath = Create();
			}
		}

		private string Create()
		{
			_fileSystemHelper.FileSystem.File.Create(_filePath);

			return _filePath;
		}
	}
}

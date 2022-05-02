using RetroGames.Game.Structure.Hdd;
using RetroGames.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Game.Structure.Folders
{
	public class GameFolder : IGameFolder
	{
		private readonly IInstallationHdd _installationHdd;
		private readonly IFileSystemHelper _fileSystemHelper;

		public GameFolder(IInstallationHdd installationHdd, IFileSystemHelper fileSystemHelper)
		{
			_installationHdd = installationHdd;
			_fileSystemHelper = fileSystemHelper;
		}

		private string _folderPath;

		public string GameFolderPath { get; set; }

		public void CreateGameFolder()
		{
			_installationHdd.GetInstallationHddName();
			_folderPath = _installationHdd.HddName + GameSettings.Default.GameDirectory;
			
			if (!_fileSystemHelper.FileSystem.Directory.Exists(_folderPath))
			{
				GameFolderPath = Create();
			}
		}

		private string Create()
		{
			_fileSystemHelper.FileSystem.Directory.CreateDirectory(_folderPath);

			return _folderPath;
		}
	}
}

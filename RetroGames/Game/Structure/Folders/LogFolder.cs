using RetroGames.Game.Structure.Hdd;
using RetroGames.Game.Structure.Helper;
using RetroGames.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Game.Structure.Folders
{
	public class LogFolder : ILogFolder
	{
		private readonly IInstallationHdd _installationHdd;
		private readonly IFileSystemHelper _fileSystemHelper;

		public LogFolder(IInstallationHdd installationHdd, IFileSystemHelper fileSystemHelper)
		{
			_installationHdd = installationHdd;
			_fileSystemHelper = fileSystemHelper;
		}

		private string _folderPath;

		public string LogFolderPath { get; set; }

		public void CreateLogFolder()
		{
			_installationHdd.GetInstallationHddName();
			_folderPath = _installationHdd.HddName + GameSettings.Default.LogDirectory;

			if (!_fileSystemHelper.FileSystem.Directory.Exists(_folderPath))
			{
				LogFolderPath = Create();
			}		
		}

		private string Create()
		{
			_fileSystemHelper.FileSystem.Directory.CreateDirectory(_folderPath);

			return _folderPath;
		}
	}
}

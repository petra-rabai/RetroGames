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
	public class UserFolder : IUserFolder
	{
		private readonly IInstallationHdd _installationHdd;
		private readonly IFileSystemHelper _fileSystemHelper;

		public UserFolder(IInstallationHdd installationHdd, IFileSystemHelper fileSystemHelper)
		{
			_installationHdd = installationHdd;
			_fileSystemHelper = fileSystemHelper;
		}

		private string _folderPath;

		public string UserFolderPath { get; set; }

		public void CreateUserFolder()
		{
			_installationHdd.GetInstallationHddName();
			_folderPath = _installationHdd.HddName + GameSettings.Default.UserDirectory;

			if (!_fileSystemHelper.FileSystem.Directory.Exists(_folderPath))
			{
				UserFolderPath = Create();
			}
				
		}

		private string Create()
		{
			_fileSystemHelper.FileSystem.Directory.CreateDirectory(_folderPath);

			return _folderPath;
		}
	}
}

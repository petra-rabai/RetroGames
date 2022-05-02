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
	public class UserFile : IUserFile
	{
		private readonly IUserFolder _userFolder;
		private readonly IFileSystemHelper _fileSystemHelper;

		public UserFile(IUserFolder userFolder, IFileSystemHelper fileSystemHelper)
		{
			_userFolder = userFolder;
			_fileSystemHelper = fileSystemHelper;
		}

		private string _filePath;

		public string UserFilePath { get; set; }

		public void CreateUserFile()
		{
			_userFolder.CreateUserFolder();
			_filePath = _userFolder.UserFolderPath + GameSettings.Default.UserFile;

			if (!_fileSystemHelper.FileSystem.File.Exists(_filePath))
			{
				UserFilePath = Create();
			}
		}

		private string Create()
		{
			_fileSystemHelper.FileSystem.File.Create(_filePath);

			return _filePath;
		}
	}
}

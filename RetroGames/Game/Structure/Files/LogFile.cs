using RetroGames.Game.Structure.Folders;
using RetroGames.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Game.Structure.Files
{
	public class LogFile : ILogFile
	{
		private readonly ILogFolder _logFolder;
		private readonly IFileSystemHelper _fileSystemHelper;

		public LogFile(ILogFolder logFolder, IFileSystemHelper fileSystemHelper)
		{
			_logFolder = logFolder;
			_fileSystemHelper = fileSystemHelper;
		}

		private string _filePath;

		public string LogFilePath { get; set; }

		public void CreateLogFolder()
		{
			_logFolder.CreateLogFolder();
			_filePath = _logFolder.LogFolderPath + GameSettings.Default.LogFile;

			if (!_fileSystemHelper.FileSystem.File.Exists(_filePath))
			{
				LogFilePath = Create();
			}
		}

		private string Create()
		{
			_fileSystemHelper.FileSystem.File.Create(_filePath);

			return _filePath;
		}
	}
}

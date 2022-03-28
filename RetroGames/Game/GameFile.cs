using RetroGames.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class GameFile : IGameDirectory, IGameFile
	{
		public string GameDirectoryPath { get; set; }
		public bool IsGameFilesExist { get; set; }
		public string GameFilePath { get; set; }
		public string UserFilePath { get; set; }
		public string LogFilePath { get; set; }
		public string UserDirectoryPath { get; set; }
		public string LogDirectoryPath { get; set; }
		GameDirectory GameDirectory { get; set; } = new GameDirectory();

		public bool CheckGameFilesCreated()
		{
			CreateGameFiles();

			if (!File.Exists(UserFilePath) && !File.Exists(GameFilePath) && !File.Exists(LogFilePath))
			{
				IsGameFilesExist = false;
			}
			else
			{
				IsGameFilesExist = true;
			}

			return IsGameFilesExist;
		}

		private void CreateGameFiles()
		{
			GameDirectory.CheckGameDirectoriesExist();

			CreateGameFile();
			CreateUserFile();
			CreateLogFile();
		}

		private string CreateGameFile()
		{
			GameDirectoryPath = GameDirectory.GameDirectoryPath;
			GameFilePath = GameDirectoryPath + GameSettings.Default.GameFile;
			
			FileStream gameFileStream = new FileStream(GameFilePath, FileMode.Create);
			gameFileStream.Close();

			return GameFilePath;
		}

		private string CreateUserFile()
		{
			UserDirectoryPath = GameDirectory.UserDirectoryPath;
			UserFilePath = UserDirectoryPath + GameSettings.Default.UserFile;
			
			FileStream userFileStream = new FileStream(UserFilePath, FileMode.Create);
			userFileStream.Close();
				
			return UserFilePath;
		}

		private string CreateLogFile()
		{
			LogDirectoryPath = GameDirectory.LogDirectoryPath;
			LogFilePath = LogDirectoryPath + GameSettings.Default.LogFile;

			FileStream logFileStream = new FileStream(LogFilePath, FileMode.Create);
			logFileStream.Close();
			
			return LogFilePath;
		}
	}
}

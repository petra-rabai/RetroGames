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
		public bool IsGameDirectoiesExist { get; set; }
		public bool IsGameFilesExist { get; set; }
		public string GameFilePath { get; set; }
		public string UserFilePath { get; set; }
		public string LogFilePath { get; set; }
		public string UserDirectoryPath { get; set; }
		public string LogDirectoryPath { get; set; }
		GameDirectory GameDirectory { get; set; } = new GameDirectory();

		public bool CheckGameFilesCreated()
		{
			CreateGameFile();
			CreateUserFile();
			CreateLogFile();

			return IsGameFilesExist;
		}

		private string CreateGameFile()
		{
			IsGameDirectoiesExist = GameDirectory.IsGameDirectoiesExist;
			GameDirectoryPath = GameDirectory.GameDirectoryPath;

			if (IsGameDirectoiesExist)
			{
				File.Create(GameDirectoryPath + GameSettings.Default.GameFile);
				IsGameFilesExist = true;
			}
			else
			{
				IsGameFilesExist = false;
			}


			return GameFilePath;
		}

		private string CreateUserFile()
		{
			IsGameDirectoiesExist = GameDirectory.IsGameDirectoiesExist;
			UserDirectoryPath = GameDirectory.UserDirectoryPath;

			if (IsGameDirectoiesExist)
			{
				File.Create(UserDirectoryPath + GameSettings.Default.UserFile);
				IsGameFilesExist = true;
			}
			else
			{
				IsGameFilesExist = false;
			}


			return UserFilePath;
		}

		private string CreateLogFile()
		{
			IsGameDirectoiesExist = GameDirectory.IsGameDirectoiesExist;
			LogDirectoryPath = GameDirectory.LogDirectoryPath;

			if (IsGameDirectoiesExist)
			{
				File.Create(LogDirectoryPath + GameSettings.Default.LogFile);
				IsGameFilesExist = true;
			}
			else
			{
				IsGameFilesExist = false;
			}


			return LogFilePath;
		}
	}
}

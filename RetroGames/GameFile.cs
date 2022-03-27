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
		public bool IsGameDirectoryExist { get; set; }
		public bool IsGameFileExist { get; set; }
		public string GameFilePath { get; set; }
		GameDirectory GameDirectory { get; set; } = new GameDirectory();

		public bool CheckGameFileCreated()
		{
			CreateGameFile();

			return IsGameFileExist;
		}

		private string CreateGameFile()
		{
			IsGameDirectoryExist = GameDirectory.IsGameDirectoryExist;
			GameDirectoryPath = GameDirectory.GameDirectoryPath;

			if (IsGameDirectoryExist)
			{
				File.Create(GameDirectoryPath + GameSettings.Default.GameFile);
				IsGameFileExist = true;
			}
			else
			{
				IsGameFileExist = false;
			}


			return GameFilePath;
		}
	}
}

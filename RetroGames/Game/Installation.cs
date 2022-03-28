using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class Installation : IGameFile, IInstallation
	{
		public bool IsInstallationSuccess { get; set; }
		public string GameFilePath { get; set; }
		public string UserFilePath { get; set; }
		public string LogFilePath { get; set; }
		GameFile GameFile { get; set; } = new GameFile();

		public bool CheckInstallationSuccess()
		{
			GameFile.CheckGameFilesCreated();

			GameFilePath = GameFile.GameFilePath;
			UserFilePath = GameFile.UserFilePath;
			LogFilePath = GameFile.LogFilePath;

			if (File.Exists(GameFilePath) && File.Exists(UserFilePath) && File.Exists(LogFilePath))
			{
				IsInstallationSuccess = true;
			}
			else
			{
				IsInstallationSuccess = false;
			}

			return IsInstallationSuccess;
		}


	}
}

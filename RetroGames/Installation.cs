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
		public bool IsGameFilesExist { get; set; }
		GameFile GameFile { get; set; } = new GameFile();

		public bool CheckInstallationSuccess()
		{
			CheckGamePath();
			CheckLogPath();
			CheckUserPath();

			return IsInstallationSuccess;
		}

		private void CheckGamePath()
		{
			GameFilePath = GameFile.GameFilePath;

			if (Directory.Exists(GameFilePath))
			{
				IsInstallationSuccess = true;
			}
			else
			{
				IsInstallationSuccess = false;
			}
		}

		private void CheckUserPath()
		{
			UserFilePath = GameFile.UserFilePath;

			if (Directory.Exists(UserFilePath))
			{
				IsInstallationSuccess = true;
			}
			else
			{
				IsInstallationSuccess = false;
			}
		}
		private void CheckLogPath()
		{
			LogFilePath = GameFile.LogFilePath;

			if (Directory.Exists(LogFilePath))
			{
				IsInstallationSuccess = true;
			}
			else
			{
				IsInstallationSuccess = false;
			}
		}


	}
}

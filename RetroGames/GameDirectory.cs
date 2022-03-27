using RetroGames.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class GameDirectory : IDrive, IGameDirectory
	{
		public string InstallationDrive { get; set; }
		public bool IsInstallationDriveSelected { get; set; }
		Drive Drive { get; set; } = new Drive();
		public bool IsGameDirectoryExist { get; set; }
		public string GameDirectoryPath { get; set; }

		public bool CheckGameDirectoryCreated()
		{
			CreateGameDirectory();

			return IsGameDirectoryExist;
		}

		private string CreateGameDirectory()
		{
			InstallationDrive = Drive.SelectInstallationDrive();

			if (!Directory.Exists(InstallationDrive + GameSettings.Default.GameDirectory))
			{
				Directory.CreateDirectory(InstallationDrive + GameSettings.Default.GameDirectory);
				IsGameDirectoryExist = true;
			}
			else
			{
				IsGameDirectoryExist = false;
			}

			return GameDirectoryPath;
		}

	}
}

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
		public bool IsGameDirectoiesExist { get; set; }
		public string GameDirectoryPath { get; set; }
		public string UserDirectoryPath { get; set; }
		public string LogDirectoryPath { get; set; }
		public bool CheckGameDirectoriesCreated()
		{
			CreateGameDirectory();
			CreateUserDirectory();
			CreateLogDirectory();

			return IsGameDirectoiesExist;
		}

		private string CreateGameDirectory()
		{
			InstallationDrive = Drive.SelectInstallationDrive();

			if (!Directory.Exists(InstallationDrive + GameSettings.Default.GameDirectory))
			{
				Directory.CreateDirectory(InstallationDrive + GameSettings.Default.GameDirectory);
				IsGameDirectoiesExist = true;
			}
			else
			{
				IsGameDirectoiesExist = false;
			}

			return GameDirectoryPath;
		}

		private string CreateUserDirectory()
		{
			InstallationDrive = Drive.SelectInstallationDrive();

			if (!Directory.Exists(InstallationDrive + GameSettings.Default.UserDirectory))
			{
				Directory.CreateDirectory(InstallationDrive + GameSettings.Default.UserDirectory);
				IsGameDirectoiesExist = true;
			}
			else
			{
				IsGameDirectoiesExist = false;
			}

			return UserDirectoryPath;
		}

		private string CreateLogDirectory()
		{
			InstallationDrive = Drive.SelectInstallationDrive();

			if (!Directory.Exists(InstallationDrive + GameSettings.Default.LogDirectory))
			{
				Directory.CreateDirectory(InstallationDrive + GameSettings.Default.LogDirectory);
				IsGameDirectoiesExist = true;
			}
			else
			{
				IsGameDirectoiesExist = false;
			}

			return LogDirectoryPath;
		}

	}
}

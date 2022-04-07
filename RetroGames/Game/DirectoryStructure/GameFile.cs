using RetroGames.Properties;
using System.IO;

namespace RetroGames
{
	public class GameFile : IGameFile
	{
		private IGameDirectory gameDirectory;
		private IDrive drive;
		public GameFile(IDrive drive, IGameDirectory gameDirectory)
		{
			this.drive = drive;
			this.gameDirectory = gameDirectory;
		}
		public string GameDirectoryPath { get; set; }
		public bool IsGameFilesExist { get; set; }
		public string GameFilePath { get; set; }
		public string UserFilePath { get; set; }
		public string LogFilePath { get; set; }
		public string UserDirectoryPath { get; set; }
		public string LogDirectoryPath { get; set; }

		public bool CheckGameFilesCreated()
		{
			drive.GetInstallationDrive(' ');
			UserFilePath = drive.InstallationDrive + GameSettings.Default.UserDirectory + GameSettings.Default.UserFile;
			LogFilePath = drive.InstallationDrive + GameSettings.Default.LogDirectory + GameSettings.Default.LogFile;
			GameFilePath = drive.InstallationDrive + GameSettings.Default.GameDirectory + GameSettings.Default.GameFile;

			if (!File.Exists(UserFilePath) && !File.Exists(GameFilePath) && !File.Exists(LogFilePath))
			{
				CreateGameFiles();
			}
			else
			{
				IsGameFilesExist = true;
			}

			return IsGameFilesExist;
		}

		private void CreateGameFiles()
		{
			gameDirectory.CheckGameDirectoriesExist();

			CreateGameFile();
			CreateUserFile();
			CreateLogFile();
		}

		private string CreateGameFile()
		{
			GameDirectoryPath = gameDirectory.GameDirectoryPath;
			GameFilePath = GameDirectoryPath + GameSettings.Default.GameFile;
			
			FileStream gameFileStream = new FileStream(GameFilePath, FileMode.Create);
			gameFileStream.Close();

			return GameFilePath;
		}

		private string CreateUserFile()
		{
			UserDirectoryPath = gameDirectory.UserDirectoryPath;
			UserFilePath = UserDirectoryPath + GameSettings.Default.UserFile;
			
			FileStream userFileStream = new FileStream(UserFilePath, FileMode.Create);
			userFileStream.Close();
				
			return UserFilePath;
		}

		private string CreateLogFile()
		{
			LogDirectoryPath = gameDirectory.LogDirectoryPath;
			LogFilePath = LogDirectoryPath + GameSettings.Default.LogFile;

			FileStream logFileStream = new FileStream(LogFilePath, FileMode.Create);
			logFileStream.Close();
			
			return LogFilePath;
		}
	}
}

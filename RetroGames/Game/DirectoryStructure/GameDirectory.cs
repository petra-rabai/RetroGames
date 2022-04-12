﻿using RetroGames.Properties;
using System.IO;
using System.IO.Abstractions;

namespace RetroGames.Games.DirectoryStructure
{
	public class GameDirectory : IGameDirectory
	{
		private IDrive _drive;
		IFileSystem _fileSystem;
		public GameDirectory(IDrive drive, IFileSystem fileSystem)
		{
			_drive = drive;
			_fileSystem = fileSystem;
		}

		public string InstallationDrive { get; set; }
		public bool IsInstallationDriveSelected { get; set; }
		public bool IsGameDirectoriesExist { get; set; }
		public string GameDirectoryPath { get; set; }
		public string UserDirectoryPath { get; set; }
		public string LogDirectoryPath { get; set; }

		public bool CheckGameDirectoriesExist()
		{
			GetInstallationDrive();

			GameDirectoryPath = InstallationDrive + GameSettings.Default.GameDirectory;
			UserDirectoryPath = InstallationDrive + GameSettings.Default.UserDirectory;
			LogDirectoryPath = InstallationDrive + GameSettings.Default.LogDirectory;

			if (!_fileSystem.Directory.Exists(GameDirectoryPath) && !_fileSystem.Directory.Exists(UserDirectoryPath) && !_fileSystem.Directory.Exists(LogDirectoryPath))
			{
				IsGameDirectoriesExist = false;

				CreateGameDirectories();
			}
			else
			{
				IsGameDirectoriesExist = true;
			}

			return IsGameDirectoriesExist;
		}

		public void CreateGameDirectories()
		{
			CreateGameDirectory();
			CreateUserDirectory();
			CreateLogDirectory();
		}

		private string CreateGameDirectory()
		{
			GameDirectoryPath = InstallationDrive + GameSettings.Default.GameDirectory;

			_fileSystem.Directory.CreateDirectory(GameDirectoryPath);

			return GameDirectoryPath;
		}

		private string GetInstallationDrive()
		{
			_drive.GetInstallationDrive(_drive.PlayerPressedKey);

			InstallationDrive = _drive.InstallationDrive;

			IsInstallationDriveSelected = _drive.IsInstallationDriveSelected;

			return InstallationDrive;
		}

		private string CreateUserDirectory()
		{
			UserDirectoryPath = InstallationDrive + GameSettings.Default.UserDirectory;
			_fileSystem.Directory.CreateDirectory(UserDirectoryPath);
			
			return UserDirectoryPath;
		}

		private string CreateLogDirectory()
		{
			LogDirectoryPath = InstallationDrive + GameSettings.Default.LogDirectory;

			_fileSystem.Directory.CreateDirectory(LogDirectoryPath);

			return LogDirectoryPath;
		}
	}
}
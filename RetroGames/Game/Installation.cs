﻿using System;
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
		InstallationUI UI { get; set; } = new InstallationUI();

		public void InstallationProcess(MainScreen mainScreen, Player player, Drive drive, GameDirectory gameDirectory, GameFile gameFile)
		{
			UI.InstallationUIInitialize();
			WriteDriveListToUI(drive);

			mainScreen.WaitForInput();

			if (mainScreen.WaitForUserPromptDisplayed)
			{
				drive.GetPlayerPressedKey(player);
				CheckInstallationSuccess(drive,gameDirectory,gameFile);
			}
		}

		private void WriteDriveListToUI(Drive drive)
		{
			int key;
			string driveName;
			
			drive.GetDriveList();
			
			foreach (KeyValuePair<int, string> choosedisk in drive.DriveList)
			{
				key = choosedisk.Key;
				driveName = choosedisk.Value;
				UI.DrivelistUI(key,driveName);
			}
		}

		
		public bool CheckInstallationSuccess(Drive drive,GameDirectory gameDirectory, GameFile gameFile)
		{
			gameFile.CheckGameFilesCreated(drive,gameDirectory);

			GameFilePath = gameFile.GameFilePath;
			UserFilePath = gameFile.UserFilePath;
			LogFilePath = gameFile.LogFilePath;

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

using System.Collections.Generic;
using System.IO;

namespace RetroGames
{
	public class Installation : IInstallation
	{
		private IGameFile gameFile;
		private IInstallationUI installationUI;
		private IMainScreen mainScreen;
		private IDrive drive;

		public Installation(IGameFile gameFile,
					  IInstallationUI installationUI,
					  IMainScreen mainScreen,
					  IDrive drive)
		{
			this.gameFile = gameFile;
			this.installationUI = installationUI;
			this.mainScreen = mainScreen;
			this.drive = drive;

		}

		public bool IsInstallationSuccess { get; set; }
		public string GameFilePath { get; set; }
		public string UserFilePath { get; set; }
		public string LogFilePath { get; set; }
		
		private bool installationCanStart;


		public void InstallationProcess()
		{
			installationUI.InstallationUIInitialize();
			WriteDriveListToUI();

			mainScreen.WaitForInputSuccess();

			if (mainScreen.WaitForUserPromptDisplayed)
			{
				drive.GetPlayerPressedKey();
				EreaseDriveList();
				CheckInstallationCanStart();
				if (installationCanStart)
				{
					CheckInstallationSuccess();
				}
				else
				{
					IsInstallationSuccess = false;
					mainScreen.MainScreenInitialize();
				}
			}
		}

		private bool CheckInstallationCanStart()
		{
			if (drive.PlayerPressedKey == 'K')
			{
				installationCanStart = false;
			}
			else
			{
				installationCanStart = true;
			}
			return installationCanStart;
		}
		private void WriteDriveListToUI()
		{
			int key;
			string driveName;
			
			drive.GetDriveList();
			
			foreach (KeyValuePair<int, string> choosedisk in drive.DriveList)
			{
				key = choosedisk.Key;
				driveName = choosedisk.Value;
				installationUI.DrivelistUI(key,driveName);
			}
				
		}

		private void EreaseDriveList()
		{
			
			for (int i = drive.DriveList.Count; i >= 0; i--)
			{
				drive.DriveList.Remove(i);
			}
			
		}
		
		public bool CheckInstallationSuccess()
		{
			gameFile.CheckGameFilesCreated();

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

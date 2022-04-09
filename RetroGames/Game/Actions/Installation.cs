using System.Collections.Generic;
using System.IO;

namespace RetroGames.Games.Actions
{
	public class Installation : IInstallation
	{
		private IGameFile _gameFile;
		private IInstallationUI _installationUI;
		private IMainScreen _mainScreen;
		private IDrive _drive;

		public Installation(IGameFile gameFile,
					  IInstallationUI installationUI,
					  IMainScreen mainScreen,
					  IDrive drive)
		{
			_gameFile = gameFile;
			_installationUI = installationUI;
			_mainScreen = mainScreen;
			_drive = drive;
		}

		public bool IsInstallationSuccess { get; set; }
		public string GameFilePath { get; set; }
		public string UserFilePath { get; set; }
		public string LogFilePath { get; set; }

		private bool installationCanStart;

		public void InstallationProcess()
		{
			_installationUI.InstallationUIInitialize();
			WriteDriveListToUI();

			_mainScreen.WaitForInputSuccess();

			if (_mainScreen.WaitForUserPromptDisplayed)
			{
				_drive.GetPlayerPressedKey();
				EreaseDriveList();
				CheckInstallationCanStart();
				if (installationCanStart)
				{
					CheckInstallationSuccess();
				}
				else
				{
					IsInstallationSuccess = false;
					_mainScreen.MainScreenInitialize();
				}
			}
		}

		private bool CheckInstallationCanStart()
		{
			if (_drive.PlayerPressedKey == 'K')
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

			_drive.GetDriveList();

			foreach (KeyValuePair<int, string> choosedisk in _drive.DriveList)
			{
				key = choosedisk.Key;
				driveName = choosedisk.Value;
				_installationUI.DrivelistUI(key, driveName);
			}
		}

		private void EreaseDriveList()
		{
			for (int i = _drive.DriveList.Count; i >= 0; i--)
			{
				_drive.DriveList.Remove(i);
			}
		}

		public bool CheckInstallationSuccess()
		{
			_gameFile.CheckGameFilesCreated();

			GameFilePath = _gameFile.GameFilePath;
			UserFilePath = _gameFile.UserFilePath;
			LogFilePath = _gameFile.LogFilePath;

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
using System.Collections.Generic;
using RetroGames.Game.DirectoryStructure;
using RetroGames.Game.UI;
using RetroGames.Person.Actions;

namespace RetroGames.Game.Actions
{
	public class Installation : IInstallation
	{
		private readonly IGameFile _gameFile;
		private readonly IInstallationUI _installationUI;
		private readonly IMainScreen _mainScreen;
		private readonly IDrive _drive;
		private readonly IPlayerInteraction _playerInteraction;

		public Installation(IGameFile gameFile,
					  IInstallationUI installationUI,
					  IMainScreen mainScreen,
					  IDrive drive,
					  IPlayerInteraction playerInteraction)
		{
			_gameFile = gameFile;
			_installationUI = installationUI;
			_mainScreen = mainScreen;
			_drive = drive;
			_playerInteraction = playerInteraction;
		}

		public bool IsInstallationSuccess { get; set; }
		public string GameFilePath { get; set; }
		public string UserFilePath { get; set; }
		public string LogFilePath { get; set; }
		public char PlayerPressedKey { get; set; }

		private bool installationCanStart;
		private bool isWaitForUserPromptDisplayed;
		private Dictionary<int, string> driveList = new Dictionary<int, string>();
		private bool IsGameFilesExist;
		public void InstallationProcess()
		{
			_installationUI.InstallationUIInitialize();
			
			WriteDriveListToUI();

			CheckWaitForInputSuccess();

			if (isWaitForUserPromptDisplayed)
			{
				GetPlayerPressedKey();
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

		private char GetPlayerPressedKey()
		{
			PlayerPressedKey = _playerInteraction.GetPlayerKeyFromConsole();

			return PlayerPressedKey;
		}


		private bool CheckWaitForInputSuccess()
		{
			isWaitForUserPromptDisplayed = _mainScreen.WaitForInputSuccess();

			return isWaitForUserPromptDisplayed;
		}

		private bool CheckInstallationCanStart()
		{
			if (PlayerPressedKey == 'K')
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

			GetDriveList();

			foreach (KeyValuePair<int, string> choosedisk in driveList)
			{
				key = choosedisk.Key;
				driveName = choosedisk.Value;
				_installationUI.DrivelistUI(key, driveName);
			}
		}

		private Dictionary<int, string> GetDriveList()
		{
			driveList = _drive.GetDriveList();

			return driveList;
		}

		private void EreaseDriveList()
		{
			for (int i = driveList.Count; i >= 0; i--)
			{
				driveList.Remove(i);
			}
			_drive.DriveList = driveList;
		}

		public bool CheckInstallationSuccess()
		{
			CheckGameFilesExsit();

			if (IsGameFilesExist)
			{
				IsInstallationSuccess = true;
			}
			else
			{
				IsInstallationSuccess = false;
			}

			return IsInstallationSuccess;
		}

		private bool CheckGameFilesExsit()
		{
			IsGameFilesExist = _gameFile.CheckGameFilesCreated();

			GameFilePath = _gameFile.GameFilePath;
			UserFilePath = _gameFile.UserFilePath;
			LogFilePath = _gameFile.LogFilePath;

			return IsGameFilesExist;
		}
	}
}
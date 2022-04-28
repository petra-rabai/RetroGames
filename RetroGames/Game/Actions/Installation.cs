﻿using RetroGames.Game.DirectoryStructure;
using RetroGames.Game.UI;
using RetroGames.Person.Actions;
using System.Collections.Generic;

namespace RetroGames.Game.Actions
{
	public class Installation : IInstallation
	{
		private readonly IGameFile _gameFile;
		private readonly IInstallationUi _installationUi;
		private readonly IScreen _screen;
		private readonly IDrive _drive;


		public Installation(IGameFile gameFile,
					  IInstallationUi installationUi,
					  IScreen screen,
					  IDrive drive)
		{
			_gameFile = gameFile;
			_installationUi = installationUi;
			_screen = screen;
			_drive = drive;
		}

		public bool IsInstallationSuccess { get; set; }
		public string GameFilePath { get; set; }
		public string UserFilePath { get; set; }
		public string LogFilePath { get; set; }
		public char InstallationOptionKey { get; set; }

		private bool _installationCanStart;
		private bool _isWaitForUserPromptDisplayed;
		private Dictionary<int, string> _driveList = new Dictionary<int, string>();
		private bool _isGameFilesExist;

		public void Start() 
		{
			InstallationProcess();
		}

		private void InstallationProcess()
		{
				_screen.ScreenInitialize();

				_installationUi.InstallationUiInitialize();

				WriteDriveListToUi();

				_isWaitForUserPromptDisplayed = CheckWaitForInputSuccess();

				if (_isWaitForUserPromptDisplayed)
				{
					InstallationOptionKey = SetInstallationOptionKey();
					EreaseDriveList();
					_installationCanStart = CheckInstallationCanStart();
					if (_installationCanStart)
					{
						CheckInstallationSuccess();
					}
					else
					{
						IsInstallationSuccess = false;
						_screen.MainScreenInitialize();
					}
				}
			
		}

		private char SetInstallationOptionKey()
		{
			InstallationOptionKey = _drive.SetDriveDecisionFromPlayer();

			return InstallationOptionKey;
		}

		private bool CheckWaitForInputSuccess()
		{
			_isWaitForUserPromptDisplayed = _screen.WaitForInputSuccess();

			return _isWaitForUserPromptDisplayed;
		}

		private bool CheckInstallationCanStart()
		{
			if (InstallationOptionKey == 'K')
			{
				_installationCanStart = false;
			}
			else
			{
				_installationCanStart = true;
			}
			return _installationCanStart;
		}

		private void WriteDriveListToUi()
		{
			int key;
			string driveName;

			_driveList = GetDriveList();

			foreach (KeyValuePair<int, string> choosedisk in _driveList)
			{
				key = choosedisk.Key;
				driveName = choosedisk.Value;
				_installationUi.DrivelistUi(key, driveName);
			}
		}

		private Dictionary<int, string> GetDriveList()
		{
			_driveList = _drive.SetDriveList();

			return _driveList;
		}

		private void EreaseDriveList()
		{
			for (int i = _driveList.Count; i >= 0; i--)
			{
				_driveList.Remove(i);
			}
			_drive.DriveList = _driveList;
		}

		public bool CheckInstallationSuccess()
		{
			_isGameFilesExist = CheckGameFilesExsit();

			if (_isGameFilesExist)
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
			_isGameFilesExist = _gameFile.CheckGameFilesCreated();

			GameFilePath = _gameFile.GameFilePath;
			UserFilePath = _gameFile.UserFilePath;
			LogFilePath = _gameFile.LogFilePath;

			return _isGameFilesExist;
		}
	}
}
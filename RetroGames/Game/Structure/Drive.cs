using RetroGames.Person.Actions;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;

namespace RetroGames.Game.DirectoryStructure
{
	public class Drive : IDrive
	{
		private readonly IPlayerInteraction _playerInteraction;

		public Drive(IPlayerInteraction playerInteraction, )
		{
			_playerInteraction = playerInteraction;
			
		}

		public string InstallationDrive { get; set; }
		
		
		
		private bool _isInstallationDriveSelected;
		
		private char _driveDecision;
		private char _playerPressedKey;
		private double[] _freeHddSpace;
		private string _defaultDrive;
		
		private bool _isPlayerPressedKeySuccess;
		private long[] _availableFreeSpace;
		private string[] _driveName;

		public string SetInstallationDrive(int driveCount)
		{
			FileSystemInit();

			DriveList = SetDriveList();
			
			if (driveCount == 0)
			{
				driveCount = DriveList.Count;
			}
			
			_isPlayerPressedKeySuccess = CheckIsPlayerPressedKey();
			
			InstallationDrive = ChooseInstallationDrive(_isPlayerPressedKeySuccess, driveCount);

			return InstallationDrive;
		}

		public char SetDriveDecisionFromPlayer()
		{
			_driveDecision = SetPlayerPressedKey();

			return _driveDecision;
		}

		public Dictionary<int, string> SetDriveList()
		{
			_driveInfo = SetDriveInfo();

			_availableDrives = CollectAvailableDrives();

			return DriveList;
		}

		private void FileSystemInit()
		{
			_fileSystemHelper.FileSystemInit();
		}

		

	private string[] CollectAvailableDrives()
		{
			_availableDrives = new string[_driveInfo.Length];

			for (int i = 0; i < _driveInfo.Length; i++)
			{
				_availableDrives[i] = _driveInfo[i].Name;
			}
			

			return _availableDrives;
		}

		private bool CheckIsPlayerPressedKey()
		{
			if (_playerPressedKey != '*')
			{
				_isPlayerPressedKeySuccess = true;
			}
			else
			{
				_isPlayerPressedKeySuccess = false;
			}

			return _isPlayerPressedKeySuccess;
		}

		private char SetPlayerPressedKey()
		{
			_playerPressedKey = _playerInteraction.ReadPlayerKeyFromConsole();

			return _playerPressedKey;
		}

		private string ChooseInstallationDrive(bool hitKeySuccess, int driveCount)
		{
			if (hitKeySuccess)
			{
				_defaultDrive = SetDefaultDrive();

				_driveDecision = SetDriveDecisionFromPlayer();

				_isInstallationDriveSelected = InstallationDriveSelection(driveCount);
			}
			else
			{
				_defaultDrive = SetDefaultDrive();

				InstallationDrive = _defaultDrive;
			}

			return InstallationDrive;
		}

		private string SetDefaultDrive()
		{
			_availableFreeSpace = GetAvailableFreeSpace(_driveInfo.Length);

			_driveName = GetDriveName(_driveInfo.Length);

			_defaultDrive = CompareDisksSpace(_driveInfo.Length, _availableFreeSpace, _driveName);

			return _defaultDrive;
		}

		private long[] GetAvailableFreeSpace(int driveCount)
		{
			_availableFreeSpace = new long[driveCount];

			for (int i = 0; i < driveCount; i++)
			{
				_availableFreeSpace[i] = _driveInfo[i].AvailableFreeSpace / _gbConvert;
			}

			return _availableFreeSpace;
		}
		private string[] GetDriveName(int driveCount)
		{
			_driveName = new string[driveCount];

			for (int i = 0; i < driveCount; i++)
			{
				_driveName[i] = _driveInfo[i].Name;
			}

			return _driveName;
		}

		private string CompareDisksSpace(int driveCount, long[] availableFreeSpace, string[] driveName)
		{
			_freeHddSpace = new double[driveCount];

			for (int i = 0; i < driveCount; i++)
			{
				_freeHddSpace[i] = Convert.ToDouble(availableFreeSpace[i]);
			}

			for (int i = 0; i < driveCount; i++)
			{
				for (int j = driveCount - 1; j >= 0; j--)
				{
					if (_freeHddSpace[i] > _freeHddSpace[j])
					{
						_defaultDrive = driveName[i];
					}
					else
					{
						_defaultDrive = driveName[j];
					}
				}
			}

			return _defaultDrive;
		}

		private bool InstallationDriveSelection(int driveCount)
		{
			if (driveCount == 1 || _driveDecision == '*')
			{
				InstallationDrive = _defaultDrive;
			}
			else
			{
				int drivelistKey = Convert.ToInt32(_driveDecision.ToString());
				InstallationDrive = DriveList[drivelistKey];
			}

			_isInstallationDriveSelected = true;

			return _isInstallationDriveSelected;
		}
	
	}
}
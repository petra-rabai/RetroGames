using RetroGames.Person.Actions;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;

namespace RetroGames.Game.DirectoryStructure
{
	public class Drive : IDrive
	{
		private readonly IPlayerInteraction _playerInteraction;
		private IFileSystem _fileSystem;

		public Drive(IPlayerInteraction playerInteraction, IFileSystem fileSystem)
		{
			_playerInteraction = playerInteraction;
			_fileSystem = fileSystem;
		}

		private const int _gbConvert = (1024 * 1024 * 1024);

		public string InstallationDrive { get; set; }
		public bool IsInstallationDriveSelected { get; set; }
		public string[] AvailableDrives { get; set; }
		public char DriveDecision { get; set; }
		public Dictionary<int, string> DriveList { get; set; } = new();
		public char PlayerPressedKey { get; set; }
		public IDriveInfo[] DriveInfo { get; set; }
		public double[] FreeHddSpace { get; set; }

		private string _defaultDrive;
		private IDriveInfoFactory _driveInfoFactory;
		private bool _isPlayerPressedKeySuccess;
		private long[] _availableFreeSpace;
		private string[] _driveName;

		public string SetInstallationDrive()
		{
			FileSystemInit();

			DriveList = SetDriveList();

			_isPlayerPressedKeySuccess = CheckIsPlayerPressedKey();

			InstallationDrive = ChooseInstallationDrive(_isPlayerPressedKeySuccess);

			return InstallationDrive;
		}

		private void FileSystemInit()
		{
			_fileSystem = new FileSystem();
		}

		public Dictionary<int, string> SetDriveList()
		{
			DriveInfo = SetDriveInfo();

			AvailableDrives = CollectAvailableDrives();

			return DriveList;
		}

		public IDriveInfo[] SetDriveInfo()
		{
			_driveInfoFactory = _fileSystem.DriveInfo;

			DriveInfo = _driveInfoFactory.GetDrives();

			return DriveInfo;
		}

		public string[] CollectAvailableDrives()
		{
			AvailableDrives = new string[DriveInfo.Length];

			for (int i = 0; i < DriveInfo.Length; i++)
			{
				AvailableDrives[i] = DriveInfo[i].Name;
			}
			for (int i = 0; i < AvailableDrives.Length; i++)
			{
				DriveList.Add(i, AvailableDrives[i]);
			}

			return AvailableDrives;
		}

		private bool CheckIsPlayerPressedKey()
		{
			if (PlayerPressedKey != '*')
			{
				_isPlayerPressedKeySuccess = true;
			}
			else
			{
				_isPlayerPressedKeySuccess = false;
			}

			return _isPlayerPressedKeySuccess;
		}

		public char SetPlayerPressedKey()
		{
			PlayerPressedKey = _playerInteraction.ReadPlayerKeyFromConsole();

			return PlayerPressedKey;
		}

		private string ChooseInstallationDrive(bool hitKeySuccess)
		{
			if (hitKeySuccess)
			{
				_defaultDrive = SetDefaultDrive();

				DriveDecision = SetDriveDecisionFromPlayer();

				IsInstallationDriveSelected = InstallationDriveSelection();
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
			_availableFreeSpace = GetAvailableFreeSpace(DriveInfo.Length);

			_driveName = GetDriveName(DriveInfo.Length);

			_defaultDrive = CompareDisksSpace(DriveInfo.Length, _availableFreeSpace, _driveName);

			return _defaultDrive;
		}

		private long[] GetAvailableFreeSpace(int driveCount)
		{
			_availableFreeSpace = new long[driveCount];

			for (int i = 0; i < driveCount; i++)
			{
				_availableFreeSpace[i] = DriveInfo[i].AvailableFreeSpace / _gbConvert;
			}

			return _availableFreeSpace;
		}
		private string[] GetDriveName(int driveCount)
		{
			_driveName = new string[driveCount];

			for (int i = 0; i < driveCount; i++)
			{
				_driveName[i] = DriveInfo[i].Name;
			}

			return _driveName;
		}

		public string CompareDisksSpace(int driveCount, long[] availableFreeSpace, string[] driveName)
		{
			FreeHddSpace = new double[driveCount];

			for (int i = 0; i < driveCount; i++)
			{
				FreeHddSpace[i] = Convert.ToDouble(availableFreeSpace[i]);
			}

			for (int i = 0; i < driveCount; i++)
			{
				for (int j = driveCount - 1; j >= 0; j--)
				{
					if (FreeHddSpace[i] > FreeHddSpace[j])
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

		public char SetDriveDecisionFromPlayer()
		{
			DriveDecision = SetPlayerPressedKey();

			return DriveDecision;
		}


		public bool InstallationDriveSelection()
		{
			if (AvailableDrives.Length == 1 || DriveDecision == '*')
			{
				InstallationDrive = _defaultDrive;
			}
			else
			{
				int drivelistKey = Convert.ToInt32(DriveDecision.ToString());
				InstallationDrive = DriveList[drivelistKey];
			}

			IsInstallationDriveSelected = true;

			return IsInstallationDriveSelected;
		}
	
	}
}
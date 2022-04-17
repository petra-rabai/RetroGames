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

		private const int GbConvert = (1024 * 1024 * 1024);

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

		public string GetInstallationDrive()
		{
			FileSystemInit();

			DriveList = GetDriveList();

			_isPlayerPressedKeySuccess = CheckIsPlayerPressedKeySuccess();

			InstallationDrive = SelectInstallationDrive(_isPlayerPressedKeySuccess);

			return InstallationDrive;
		}

		private void FileSystemInit()
		{
			_fileSystem = new FileSystem();
		}

		public Dictionary<int, string> GetDriveList()
		{
			DriveInfo = GetDriveInfo();

			AvailableDrives = CollectDrives();

			return DriveList;
		}

		public IDriveInfo[] GetDriveInfo()
		{
			_driveInfoFactory = _fileSystem.DriveInfo;

			DriveInfo = _driveInfoFactory.GetDrives();

			return DriveInfo;
		}

		public string[] CollectDrives()
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

		private bool CheckIsPlayerPressedKeySuccess()
		{
			_isPlayerPressedKeySuccess = PlayerPressedKey != '*';

			return _isPlayerPressedKeySuccess;
		}

		public char GetPlayerPressedKey()
		{
			PlayerPressedKey = _playerInteraction.GetPlayerKeyFromConsole();

			return PlayerPressedKey;
		}

		private string SelectInstallationDrive(bool hitKeySuccess)
		{
			if (hitKeySuccess)
			{
				_defaultDrive = ChooseDefaultDrive();

				DriveDecision = GetDriveDecisionFromPlayer();

				IsInstallationDriveSelected = InstallationDriveSelection();
			}
			else
			{
				_defaultDrive = ChooseDefaultDrive();

				InstallationDrive = _defaultDrive;
			}

			return InstallationDrive;
		}

		private string ChooseDefaultDrive()
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
				_availableFreeSpace[i] = DriveInfo[i].AvailableFreeSpace / GbConvert;
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

		public char GetDriveDecisionFromPlayer()
		{
			DriveDecision = GetPlayerPressedKey();

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
using System;
using System.Collections.Generic;
using System.IO.Abstractions;

namespace RetroGames.Games.DirectoryStructure
{
	public class Drive : IDrive
	{
		private IPlayerInteraction _playerInteraction;
		private IFileSystem _fileSystem;

		public Drive(IPlayerInteraction playerInteraction, IFileSystem fileSystem)
		{
			_playerInteraction = playerInteraction;
			_fileSystem = fileSystem;
		}

		private const int gBConverthelper = (1024 * 1024 * 1024);

		public string InstallationDrive { get; set; }
		public bool IsInstallationDriveSelected { get; set; }
		public string[] AvailableDrives { get; set; }
		public char DriveDecesion { get; set; }
		public Dictionary<int, string> DriveList { get; set; } = new Dictionary<int, string>();
		public char PlayerPressedKey { get; set; }
		public IDriveInfo[] DriveInfo { get; set; }
		public double[] FreeHddSpace { get; set; }

		private string defaultDrive;
		private IDriveInfoFactory driveInfoFactory;
		private bool IsPlayerPressedKeySuccess;
		private long[] availableFreeSpace;
		private string[] driveName;

		public char GetPlayerPressedKey()
		{
			PlayerPressedKey = _playerInteraction.GetPlayerKeyFromConsole();

			return PlayerPressedKey;
		}

		private void FileSystemInit()
		{
			_fileSystem = new FileSystem();
		}

		public void GetInstallationDrive(char playerHitKey)
		{
			FileSystemInit();

			GetDriveList();

			CheckIsPlayerPressdKeySuccess(playerHitKey);
			SelectInstallationDrive(IsPlayerPressedKeySuccess, playerHitKey);
		}

		public Dictionary<int, string> GetDriveList()
		{
			GetDriveInfo();
			CollectDrives();

			return DriveList;
		}

		private bool CheckIsPlayerPressdKeySuccess(char playerHitKey)
		{
			if (playerHitKey != '*')
			{
				IsPlayerPressedKeySuccess = true;
			}
			else
			{
				IsPlayerPressedKeySuccess = false;
			}
			return IsPlayerPressedKeySuccess;
		}

		private string SelectInstallationDrive(bool hitKeySuccess, char playerHitKey)
		{
			if (hitKeySuccess)
			{
				ChooseDefaultDrive();
				GetDriveDecesionFromPlayer(playerHitKey);
				InstallationDriveSelectionSuccess();
			}
			else
			{
				ChooseDefaultDrive();
				InstallationDrive = defaultDrive;
			}

			return InstallationDrive;
		}

		public char GetDriveDecesionFromPlayer(char playerHitKey)
		{
			DriveDecesion = playerHitKey;

			return DriveDecesion;
		}

		public void GetDriveInfo()
		{
			driveInfoFactory = _fileSystem.DriveInfo;

			DriveInfo = driveInfoFactory.GetDrives();
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

		private string ChooseDefaultDrive()
		{
			GetAvilableFreeSpace(DriveInfo.Length);

			GetDriveName(DriveInfo.Length);

			CompareDisksSpace(DriveInfo.Length, availableFreeSpace, driveName);

			return defaultDrive;
		}

		private string[] GetDriveName(int driveCount)
		{
			driveName = new string[driveCount];

			for (int i = 0; i < driveCount; i++)
			{
				driveName[i] = DriveInfo[i].Name;
			}

			return driveName;
		}

		private long[] GetAvilableFreeSpace(int driveCount)
		{
			availableFreeSpace = new long[driveCount];

			for (int i = 0; i < driveCount; i++)
			{
				availableFreeSpace[i] = DriveInfo[i].AvailableFreeSpace / gBConverthelper;
			}

			return availableFreeSpace;
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
						defaultDrive = driveName[i];
					}
					else
					{
						defaultDrive = driveName[j];
					}
				}
			}

			return defaultDrive;
		}

		public bool InstallationDriveSelectionSuccess()
		{
			if (AvailableDrives.Length == 1)
			{
				InstallationDrive = defaultDrive;
			}
			else
			{
				int drivelistKey = Convert.ToInt32(DriveDecesion.ToString());
				InstallationDrive = DriveList[drivelistKey];
			}

			IsInstallationDriveSelected = true;

			return IsInstallationDriveSelected;
		}
	}
}
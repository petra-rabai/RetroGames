using System;
using System.Collections.Generic;
using System.IO;

namespace RetroGames
{
	public class Drive : IDrive
	{
		private const int gBConverthelper = (1024 * 1024 * 1024);
		
		public string InstallationDrive { get; set; }
		public bool IsInstallationDriveSelected { get; set; }
		public string[] AvailableDrives { get; set; }
		public char DriveDecesion { get; set; }
		public Dictionary<int, string> DriveList { get; set; } = new Dictionary<int, string>();

		private string defaultDrive;
		private DriveInfo[] hDDs;
		private double[] freeHddSpace;
		private char playerPressedKey;
		private bool IsPlayerPressedKeySuccess;

		public char GetPlayerPressedKey(Player player)
		{
			playerPressedKey = player.GetPlayerKeyFromConsole();
			
			return playerPressedKey;
		}
		
		private bool IsPlayerPressdKeySuccess()
		{
			if (playerPressedKey != ' ')
			{
				IsPlayerPressedKeySuccess = true;
			}
			else
			{
				IsPlayerPressedKeySuccess = false;
			}
			return IsPlayerPressedKeySuccess;
		}

		public string SelectInstallationDrive()
		{
			IsPlayerPressdKeySuccess();

			if (IsPlayerPressedKeySuccess)
			{
				ChooseDefaultDrive();
				GetDriveDecesion();
				InstallationDriveSelectionSuccess();
			}
			
			return InstallationDrive;
		}

		private void GetDriveInfo()
		{
			hDDs = DriveInfo.GetDrives();
			freeHddSpace = new double[hDDs.Length];
		}

		public Dictionary <int,string> GetDriveList()
		{
			GetDriveInfo();
			
			CollectDrives();

			return DriveList;
		}
		private string[] CollectDrives()
		{
			AvailableDrives = new string[hDDs.Length];

			for (int i = 0; i < hDDs.Length; i++)
			{
				AvailableDrives[i] = hDDs[i].Name;
			}
			for (int i = 0; i < AvailableDrives.Length; i++)
			{
				DriveList.Add(i, AvailableDrives[i]);
			}

			return AvailableDrives;
		}

		private string ChooseDefaultDrive()
		{
			CompareDisksSpace();

			return defaultDrive;
		}

		private void CompareDisksSpace()
		{
			for (int i = 0; i < hDDs.Length; i++)
			{
				freeHddSpace[i] = Convert.ToDouble(hDDs[i].AvailableFreeSpace / gBConverthelper);
			}

			for (int i = 0; i < hDDs.Length; i++)
			{
				for (int j = hDDs.Length - 1; j >= 0; j--)
				{
					if (freeHddSpace[i] > freeHddSpace[j])
					{
						defaultDrive = hDDs[i].Name;
					}
					else
					{
						defaultDrive = hDDs[j].Name;
					}
				}
			}
		}

		private bool  InstallationDriveSelectionSuccess()
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

		private char GetDriveDecesion()
		{			
			DriveDecesion = playerPressedKey;

			return DriveDecesion;
		}

		

	}
}

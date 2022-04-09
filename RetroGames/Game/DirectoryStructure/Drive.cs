using System;
using System.Collections.Generic;
using System.IO;
using Unity;

namespace RetroGames
{
	public class Drive : IDrive
	{
		private IPlayerInteraction playerInteraction;

		[InjectionConstructor]
		public Drive(IPlayerInteraction playerInteraction)
		{
			this.playerInteraction = playerInteraction;
		}

		private const int gBConverthelper = (1024 * 1024 * 1024);

		public string InstallationDrive { get; set; }
		public bool IsInstallationDriveSelected { get; set; }
		public string[] AvailableDrives { get; set; }
		public char DriveDecesion { get; set; }
		public Dictionary<int, string> DriveList { get; set; } = new Dictionary<int, string>();
		public char PlayerPressedKey { get; set; }

		private string defaultDrive;
		private DriveInfo[] hDDs;
		private double[] freeHddSpace;
		private bool IsPlayerPressedKeySuccess;
		IUnityContainer playerInteractionIOC = new UnityContainer();

		public char GetPlayerPressedKey()
		{
			PlayerPressedKey = playerInteraction.GetPlayerKeyFromConsole();

			return PlayerPressedKey;
		}

		private void CreateIOC()
		{
			playerInteractionIOC.RegisterType<IPlayerInteraction, PlayerInteraction>();
		}
		public void GetInstallationDrive(char playerHitKey)
		{
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

		private char GetDriveDecesionFromPlayer(char playerHitKey)
		{
			DriveDecesion = playerHitKey;

			return DriveDecesion;
		}

		private void GetDriveInfo()
		{
			hDDs = DriveInfo.GetDrives();

			freeHddSpace = new double[hDDs.Length];
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

		private bool InstallationDriveSelectionSuccess()
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
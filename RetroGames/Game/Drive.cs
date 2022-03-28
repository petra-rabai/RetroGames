using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class Drive : IDrive
	{
		private const int gBConverthelper = (1024 * 1024 * 1024);
		
		public string InstallationDrive { get; set; }
		public bool IsInstallationDriveSelected { get; set; }
		public string[] AvailableDrives { get; set; }
		public char DriveDecesion { get; set; }

		private string defaultDrive;
		private Dictionary<int, string> DriveList = new Dictionary<int, string>();
		private DriveInfo[] hDDs;
		private double[] freeHddSpace;

		public string SelectInstallationDrive()
		{
			GetDriveInfo();
			CollectDrives();
			ChooseDefaultDrive();
			InstallationDriveSelectionSuccess();

			return InstallationDrive;
		}

		private void GetDriveInfo()
		{
			hDDs = DriveInfo.GetDrives();
			freeHddSpace = new double[hDDs.Length];
		}

		private string[] CollectDrives()
		{
			hDDs = DriveInfo.GetDrives();
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

	}
}

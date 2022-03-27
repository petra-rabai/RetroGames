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
		private Dictionary<int, string> DriveList;

		public string SelectInstallationDrive()
		{
			ChooseDefaultDrive();
			CollectDrives();

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

			return InstallationDrive;
		}


		private string ChooseDefaultDrive()
		{
			DriveInfo[] hDDs;
			double[] freeDiscSpace;
			GetFreeDiskSpace(out hDDs, out freeDiscSpace);
			CompareDisks(hDDs, freeDiscSpace);

			return defaultDrive;
		}

		private void CompareDisks(DriveInfo[] hDDs, double[] freeDiscSpace)
		{
			for (int i = 0; i < freeDiscSpace.Length; i++)
			{
				for (int j = freeDiscSpace.Length - 1; j >= 0; j--)
				{
					if (freeDiscSpace[i] > freeDiscSpace[j])
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

		private void GetFreeDiskSpace(out DriveInfo[] hDDs, out double[] freeDiscSpace)
		{
			hDDs = DriveInfo.GetDrives();
			freeDiscSpace = new double[hDDs.Length];
			for (int i = 0; i < hDDs.Length; i++)
			{
				DriveInfo drive = new DriveInfo(hDDs[i].Name);
				string driveName = drive.Name;
				DriveInfo driveInfo = new DriveInfo(driveName);
				freeDiscSpace[i] = Convert.ToDouble(driveInfo.AvailableFreeSpace / gBConverthelper);
			}
		}

		private string[] CollectDrives()
		{
			DriveInfo[] hDDs;
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

	}
}

using System.Collections.Generic;
using System.IO.Abstractions;

namespace RetroGames.Game.DirectoryStructure
{
	public interface IDrive
	{
		string[] AvailableDrives { get; set; }
		char DriveDecision { get; set; }
		IDriveInfo[] DriveInfo { get; set; }
		Dictionary<int, string> DriveList { get; set; }
		double[] FreeHddSpace { get; set; }
		string InstallationDrive { get; set; }
		bool IsInstallationDriveSelected { get; set; }
		char PlayerPressedKey { get; set; }

		string[] CollectDrives();
		string CompareDisksSpace(int driveCount, long[] availableFreeSpace, string[] driveName);
		char GetDriveDecisionFromPlayer();
		IDriveInfo[] GetDriveInfo();
		Dictionary<int, string> GetDriveList();
		string GetInstallationDrive();
		char GetPlayerPressedKey();
		bool InstallationDriveSelection();
	}
}
using System.Collections.Generic;
using System.IO.Abstractions;

namespace RetroGames.Game.DirectoryStructure
{
	public interface IDrive
	{
		string InstallationDrive { get; set; }
		bool IsInstallationDriveSelected { get; set; }
		char PlayerPressedKey { get; set; }
		Dictionary<int, string> DriveList { get; set; }
		IDriveInfo[] DriveInfo { get; set; }
		double[] FreeHddSpace { get; set; }

		void GetInstallationDrive(char playerHitKey);

		char GetPlayerPressedKey();

		Dictionary<int, string> GetDriveList();

		string[] CollectDrives();

		bool InstallationDriveSelectionSuccess();

		char GetDriveDecisionFromPlayer(char playerHitKey);

		void GetDriveInfo();

		string CompareDisksSpace(int driveCount, long[] availableFreeSpace, string[] driveName);
	}
}
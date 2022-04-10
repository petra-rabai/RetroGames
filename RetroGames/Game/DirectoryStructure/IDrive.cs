using System.Collections.Generic;

namespace RetroGames
{
	public interface IDrive
	{
		string InstallationDrive { get; set; }
		bool IsInstallationDriveSelected { get; set; }
		char PlayerPressedKey { get; set; }
		Dictionary<int, string> DriveList { get; set; }

		void GetInstallationDrive(char playerHitKey);

		char GetPlayerPressedKey();

		Dictionary<int, string> GetDriveList();

		string[] CollectDrives();

		bool InstallationDriveSelectionSuccess();

		char GetDriveDecesionFromPlayer(char playerHitKey);

		void GetDriveInfo();
	}
}
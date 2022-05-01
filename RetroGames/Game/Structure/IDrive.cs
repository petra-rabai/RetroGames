using System.Collections.Generic;

namespace RetroGames.Game.DirectoryStructure
{
	public interface IDrive
	{
		Dictionary<int, string> DriveList { get; set; }
		string InstallationDrive { get; set; }
		
		char SetDriveDecisionFromPlayer();
		Dictionary<int, string> SetDriveList();
		string SetInstallationDrive(int driveCount);
	}
}
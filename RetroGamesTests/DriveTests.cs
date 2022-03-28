using NUnit.Framework;
using RetroGames;

namespace RetroGamesTests
{
	public class DriveTests
	{
		
		
		[Test]
		public void CheckSelectInstallationDriveSuccess()
		{
			string installationdrive;

			Drive drive = new Drive();
			
			installationdrive = drive.SelectInstallationDrive();

			Assert.IsNotNull(installationdrive);
		}

		[Test]
		public void CheckInstallationDriveExistSuccess()
		{
			bool isInstallationDriveExist;
			Drive drive = new Drive();

			drive.SelectInstallationDrive();

			isInstallationDriveExist = drive.IsInstallationDriveSelected;

			Assert.IsTrue(isInstallationDriveExist);
		}

		[Test]
		public void CheckAvailableDrivesExist()
		{
			string[] availableDrives;

			Drive drive = new Drive();

			drive.SelectInstallationDrive();

			availableDrives = drive.AvailableDrives;

			Assert.IsNotNull(availableDrives);
		}



	}
}

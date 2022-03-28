using NUnit;
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

	}
}

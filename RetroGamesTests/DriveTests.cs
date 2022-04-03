using NUnit.Framework;
using RetroGames;

namespace RetroGamesTests
{
	public class DriveTests
	{
		
		[Test]
		public void GetDriveListSuccess()
		{
			Drive drive = new Drive();
			
			drive.GetDriveList();

			Assert.IsNotEmpty(drive.DriveList);
		}

		[TestCase('0')]
		[TestCase('*')]
		[Test]
		public void GetInstallationDriveSuccess(char testKey)
		{
			Drive drive = new Drive();

			drive.GetInstallationDrive(testKey);

			Assert.NotNull(drive.InstallationDrive);

		}


	}
}

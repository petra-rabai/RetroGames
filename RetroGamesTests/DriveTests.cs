using NUnit.Framework;
using RetroGames;
using FluentAssertions;


namespace RetroGamesTests
{
	public class DriveTests
	{
		
		[Test]
		public void GetDriveListSuccess()
		{
			IPlayerInteraction playerInteraction = new PlayerInteraction();
			Drive drive = new(playerInteraction);

			drive.GetDriveList();

			Assert.IsNotEmpty(drive.DriveList);
		}

		[TestCase('0')]
		[TestCase('*')]
		[Test]
		public void GetInstallationDriveSuccess(char testKey)
		{
			IPlayerInteraction playerInteraction = new PlayerInteraction();
			Drive drive = new(playerInteraction);

			drive.GetInstallationDrive(testKey);

			Assert.NotNull(drive.InstallationDrive);

		}


	}
}

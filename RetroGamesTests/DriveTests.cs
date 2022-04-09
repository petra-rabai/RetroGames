using NUnit.Framework;
using FluentAssertions;
using RetroGames;
using RetroGames.Games.DirectoryStructure;
using RetroGames.Person.Actions;

namespace RetroGamesTests
{
	public class DriveTests
	{
		private IPlayerInteraction _playerInteraction;
		public DriveTests(IPlayerInteraction playerInteraction)
		{
			_playerInteraction = playerInteraction;
		}
		
		[SetUp]
		public void InitializeDrive()
		{
			Drive drive = new(_playerInteraction);
		}
		
		[Test]
		public void GetDriveListSuccess(Drive drive)
		{
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
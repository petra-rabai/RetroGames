using NUnit.Framework;
using RetroGames;

namespace RetroGamesTests
{
	public class InstallationTests
	{
		[Test]

		public void CheckInstallationSuccess()
		{
			bool isInstallationSuccess;

			Installation installation = new Installation();
			Drive drive = new Drive();
			GameDirectory gameDirectory = new GameDirectory();
			GameFile gameFile = new GameFile();

			installation.CheckInstallationSuccess(drive,gameDirectory,gameFile);
			
			isInstallationSuccess = installation.IsInstallationSuccess;

			Assert.IsTrue(isInstallationSuccess);


		}

	}
}

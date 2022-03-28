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

			installation.CheckInstallationSuccess();
			
			isInstallationSuccess = installation.IsInstallationSuccess;

			Assert.IsTrue(isInstallationSuccess);


		}

	}
}

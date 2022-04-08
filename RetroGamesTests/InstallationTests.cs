using NUnit.Framework;
using RetroGames;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

namespace RetroGamesTests
{
	public class InstallationTests
	{
		[Test]

		public void CheckInstallationSuccess()
		{
			bool isInstallationSuccess;

			IPlayerInteraction playerInteraction = new PlayerInteraction();
			IFileSystem fileSystem = new FileSystem();
			IInstallationUI installationUI = new InstallationUI();
			IGameMenu gameMenu = new GameMenu();
			IMainScreenUI mainScreenUI = new MainScreenUI(gameMenu);
			IMainScreen mainScreen = new MainScreen(mainScreenUI);

			Drive drive = new(playerInteraction);
			GameDirectory gameDirectory = new(drive,fileSystem);
			GameFile gameFile = new(drive,gameDirectory);
			
			Installation installation = new(gameFile,installationUI,mainScreen,drive);
			
			installation.CheckInstallationSuccess();
			
			isInstallationSuccess = installation.IsInstallationSuccess;

			Assert.IsTrue(isInstallationSuccess);


		}

	}
}

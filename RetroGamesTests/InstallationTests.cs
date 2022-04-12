using Moq;
using NUnit.Framework;
using RetroGames;
using RetroGames.Games;
using RetroGames.Games.Actions;
using RetroGames.Games.DirectoryStructure;
using RetroGames.Games.UI;
using RetroGames.Person.Actions;
using System.IO.Abstractions;

namespace RetroGamesTests
{
	public class InstallationTests
	{
		[Test]
		public void CheckInstallationSuccess()
		{
			bool isInstallationSuccess;

			IPlayerInteraction playerInteraction = new PlayerInteraction();
			IInstallationUI installationUI = new InstallationUI();
			IGameMenu gameMenu = new GameMenu();
			IMainScreenUI mainScreenUI = new MainScreenUI(gameMenu);
			IMainScreen mainScreen = new MainScreen(mainScreenUI);

			Mock<IFileSystem> fileSystem = new(MockBehavior.Strict);

			Drive drive = new(playerInteraction, fileSystem.Object);

			GameDirectory gameDirectory = new(drive, fileSystem.Object);
			GameFile gameFile = new GameFile(drive, gameDirectory, fileSystem.Object);

			Installation installation = new(gameFile, installationUI, mainScreen, drive);

			installation.CheckInstallationSuccess();

			isInstallationSuccess = installation.IsInstallationSuccess;

			Assert.IsTrue(isInstallationSuccess);
		}
	}
}
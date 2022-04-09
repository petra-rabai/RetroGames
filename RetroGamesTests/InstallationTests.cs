﻿using NUnit.Framework;
using RetroGames;
using RetroGames.Games;
using RetroGames.Games.Actions;
using RetroGames.Games.DirectoryStructure;
using RetroGames.Games.UI;
using RetroGames.Person.Actions;

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

			Drive drive = new(playerInteraction);
			GameDirectory gameDirectory = new(drive);
			GameFile gameFile = new(drive, gameDirectory);

			Installation installation = new(gameFile, installationUI, mainScreen, drive);

			installation.CheckInstallationSuccess();

			isInstallationSuccess = installation.IsInstallationSuccess;

			Assert.IsTrue(isInstallationSuccess);
		}
	}
}
using RetroGames.Person.Actions;
using System;
using System.Collections.Generic;

namespace RetroGames.Game.Actions
{
	public class GameMenuNavigation : IGameMenuNavigation
	{
		private readonly IPlayerInteraction _playerInteraction;
		private readonly IMainScreen _mainScreen;
		private readonly IGameMenu _gameMenu;
		//private readonly IInstallation _installation;

		public GameMenuNavigation(IPlayerInteraction playerInteraction,
							IMainScreen mainScreen,
							IGameMenu gameMenu)
							//IInstallation installation)
		{
			//_registration = registration;
			_gameMenu = gameMenu;
			_mainScreen = mainScreen;
			//_installation = installation;
			_playerInteraction = playerInteraction;
		}

		public Dictionary<char, string> MainMenu { get; set; }
		public string ChoosedMenu { get; set; }
		public char PressedKey { get; set; }
		public string PlayerPassword { get; set; }
		public bool IsRegistered { get; set; }
		public bool IsLoggedIn { get; set; }
		public string LoginName { get; set; }
		public bool isInstallationSelected { get; private set; }
		public bool isNavigationSuccess { get; private set; }

		private char GetChoosedMenuKey()
		{
			PressedKey = GetPlayerPressedKey();

			return PressedKey;
		}

		public void MenuNavigation()
		{
			MainMenu = GetMainMenu();

			if (PressedKey == ' ')
			{
				PressedKey = GetChoosedMenuKey();
				ChoosedMenu = GetChoosedMenuFromGameMenu();
			}
			else
			{
				ChoosedMenu = GetChoosedMenuFromGameMenu();
			}

			Navigation();

		}

		private void Navigation()
		{
			switch (ChoosedMenu)
			{
				case "New Game":
					isNavigationSuccess = true;
					// Start a new game - If the user not registered or logged in drop an error
					// If Installation not success drop an error
					break;

				case "Installation":
					isNavigationSuccess = true;
					// Install the game
					//_installation.InstallationProcess();

					break;

				case "Pause Game":
					// Pause the current game
					isNavigationSuccess = true;
					break;

				case "Save Game":
					// Save the current unfinished game state
					isNavigationSuccess = true;
					break;

				case "Load Game":
					// Load the current unfinished game state
					isNavigationSuccess = true;
					break;

				case "Login":
					// Login with a registered user
					isNavigationSuccess = true;
					break;

				case "Registration":
					// If Installation not success drop an error
					isNavigationSuccess = true;
					//_registration.UserRegistration();

					break;

				case "Help":
					// Open the Help section (txt? or any other structured file?)
					isNavigationSuccess = true;
					break;

				case "Quit":
					isNavigationSuccess = true;
					_mainScreen.MainScreenExit();
					break;
			}
		}

		private Dictionary<char, string> GetMainMenu()
		{
			MainMenu = _gameMenu.MainMenu;

			return MainMenu;
		}

		private char GetPlayerPressedKey()
		{
			PressedKey = _playerInteraction.GetPlayerKeyFromConsole();

			return PressedKey;
		}

		private string GetChoosedMenuFromGameMenu()
		{
			ChoosedMenu = MainMenu[PressedKey];

			return ChoosedMenu;
		}
	}
}
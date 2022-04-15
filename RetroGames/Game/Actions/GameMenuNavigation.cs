using System;
using System.Collections.Generic;
using RetroGames.Person.Actions;

namespace RetroGames.Game.Actions
{
	public class GameMenuNavigation : IGameMenuNavigation
	{
		private readonly IPlayerInteraction _playerInteraction;
		private readonly IRegistration _registration;
		private readonly IGameMenu _gameMenu;
		private readonly IInstallation _installation;

		public GameMenuNavigation(IPlayerInteraction playerInteraction,
							IRegistration registration,
							IGameMenu gameMenu,
							IInstallation installation)
		{
			_registration = registration;
			_gameMenu = gameMenu;
			_installation = installation;
			_playerInteraction = playerInteraction;
		}

		public Dictionary<char, string> MainMenu { get; set; }
		public string ChoosedMenu { get; set; }
		public char PressedKey { get; set; }
		public string PlayerPassword { get; set; }
		public bool IsRegistered { get; set; }
		public bool IsLoggedIn { get; set; }
		public string LoginName { get; set; }

		private void GetChoosedMenu()
		{
			PressedKey = GetPlayerPressedKey();
			MainMenu = GetMainMenu();
		}

		public void MenuNavigation()
		{
			if (PressedKey == ' ')
			{
				GetChoosedMenu();
			}
			else
			{
				ChoosedMenu = GetChoosedMenuFromGameMenu();
				Navigation();
			}
		}

		private void Navigation()
		{
			switch (ChoosedMenu)
			{
				case "New Game":
					// Start a new game - If the user not registered or logged in drop an error
					// If Installation not success drop an error
					break;

				case "Installation":
					// Install the game
					_installation.InstallationProcess();

					break;

				case "Pause Game":
					// Pause the current game
					break;

				case "Save Game":
					// Save the current unfinished game state
					break;

				case "Load Game":
					// Load the current unfinished game state
					break;

				case "Login":
					// Login with a registered user
					break;

				case "Registration":
					// If Installation not success drop an error
					_registration.UserRegistration();
					break;

				case "Help":
					// Open the Help section (txt? or any other structured file?)
					break;

				case "Quit":
					Environment.Exit(0);
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
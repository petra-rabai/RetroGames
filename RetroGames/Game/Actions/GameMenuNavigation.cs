using System;
using System.Collections.Generic;

namespace RetroGames
{
	public class GameMenuNavigation : IGameMenuNavigation
	{
		private IPlayer player;
		private IRegistration registration;
		private IGameMenu gameMenu;
		private IInstallation installation;


		public GameMenuNavigation(IPlayer player,
							IRegistration registration,
							IGameMenu gameMenu,
							IInstallation installation)
		{
			this.registration = registration;
			this.gameMenu = gameMenu;
			this.installation = installation;
			this.player = player;
		}

		public Dictionary<char, string> MainMenu { get; set; }
		public string ChoosedMenu { get; set; }
		public char PressedKey { get; set; }
		public string PlayerPassword { get; set; }
		public bool IsRegistered { get; set; }
		public bool IsLoggedIn { get; set; }
		public string LoginName { get; set; }

		public void GetChoosedMenu()
		{
			GetPlayerPressedKey();
			GetMainMenu();
		}

		public void MenuNavigation()
		{
			if (PressedKey == ' ')
			{
				GetChoosedMenu();
			}
			else
			{
				GetChoosedMenuFromGameMenu();
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
					installation.InstallationProcess();

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
					registration.UserRegistration();
					break;
				case "Help":
					// Open the Help section (txt? or any other structured file?)
					break;
				case "Quit":
					Environment.Exit(0);
					break;
				default:
					break;
			}
		}

		private Dictionary<char, string> GetMainMenu()
		{
			MainMenu = gameMenu.MainMenu;

			return MainMenu;
		}

		private char GetPlayerPressedKey()
		{
			PressedKey = player.GetPlayerKeyFromConsole();

			return PressedKey;
		}

		private string GetChoosedMenuFromGameMenu()
		{
			ChoosedMenu = MainMenu[PressedKey];

			return ChoosedMenu;
		}


	}
}

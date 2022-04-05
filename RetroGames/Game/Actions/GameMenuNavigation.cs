using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class GameMenuNavigation : IGameMenu, IPlayer, IGameMenuNavigation
	{
		public Dictionary<char, string> MainMenu { get; set; }
		public string ChoosedMenu { get; set; }
		public char PressedKey { get; set; }
		public string PlayerPassword { get; set; }
		public bool IsRegistered { get; set; }
		public bool IsLoggedIn { get; set; }
		public string LoginName { get; set; }

		public void GetChoosedMenu(GameMenu gameMenu, Player player)
		{
			GetPlayerPressedKey(player);
			GetMainMenu(gameMenu);
		}

		public void MenuNavigation(GameMenu gameMenu, MainScreen mainScreen, Player player, Drive drive, Registration registration,
						  GameFile gameFile,
						  User user,
						  Password playerPassword,
						  Email playerEmail,Installation installation, GameDirectory gameDirectory, EmailValidation emailValidation,
						  PasswordValidation passwordValidation, StringCryptographer stringCryptographer)
		{
			if (PressedKey == ' ')
			{
				GetChoosedMenu(gameMenu,player);
			}
			else
			{
				GetChoosedMenuFromGameMenu();
				Navigation(mainScreen, player, drive,registration,gameFile,user,playerPassword,playerEmail,emailValidation,passwordValidation,installation,gameDirectory,gameMenu, stringCryptographer);
			}

		}

		private void Navigation(MainScreen mainScreen,
						  Player player,
						  Drive drive,
						  Registration registration,
						  GameFile gameFile,
						  User user,
						  Password playerPassword,
						  Email playerEmail,
						  EmailValidation emailValidation,
						  PasswordValidation passwordValidation,
						  Installation installation,
						  GameDirectory gameDirectory,
						  GameMenu gameMenu,
						  StringCryptographer stringCryptographer)
		{
			switch (ChoosedMenu)
			{
				case "New Game":
					// Start a new game - If the user not registered or logged in drop an error
					// If Installation not success drop an error
					break;
				case "Installation":
					// Install the game
					installation.InstallationProcess(mainScreen, player, drive,gameDirectory,gameFile,gameMenu);

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
					registration.UserRegistration(gameFile, user, playerPassword, playerEmail,emailValidation, stringCryptographer, passwordValidation,drive,gameDirectory, player);
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

		private Dictionary<char, string> GetMainMenu(GameMenu gameMenu)
		{
			MainMenu = gameMenu.MainMenu;

			return MainMenu;
		}

		private char GetPlayerPressedKey(Player player)
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

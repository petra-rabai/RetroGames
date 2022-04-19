using RetroGames.Person.Actions;
using System;
using System.Collections.Generic;

namespace RetroGames.Game.Actions
{
	public class GameMenuNavigation : IGameMenuNavigation
	{
		private readonly IPlayerInteraction _playerInteraction;
		private readonly IScreen _screen;
		private readonly IGameMenu _gameMenu;
		private readonly IGameControl _gameControl;

		public GameMenuNavigation(IPlayerInteraction playerInteraction,
							IScreen screen,
							IGameControl gameControl,
							IGameMenu gameMenu)
		{

			_gameMenu = gameMenu;
			_screen = screen;
			_playerInteraction = playerInteraction;
			_gameControl = gameControl;
		}

		public Dictionary<char, string> MainMenu { get; set; }
		public string ChoosedMenu { get; set; }
		public char PressedKey { get; set; }
		public string PlayerPassword { get; set; }
		public bool IsRegistered { get; set; }
		public bool IsLoggedIn { get; set; }
		public string LoginName { get; set; }
		public bool isNavigationSuccess { get; set; }

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

			_gameControl.Start();
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
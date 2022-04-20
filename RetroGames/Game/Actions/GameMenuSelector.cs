using RetroGames.Person.Actions;
using System;
using System.Collections.Generic;

namespace RetroGames.Game.Actions
{
	public class GameMenuSelector : IGameMenuSelector
	{
		private readonly IPlayerInteraction _playerInteraction;
		private readonly IGameMenu _gameMenu;
		private readonly IGameControl _gameControl;

		public GameMenuSelector(IPlayerInteraction playerInteraction,
							IGameControl gameControl,
							IGameMenu gameMenu)
		{

			_gameMenu = gameMenu;
			_playerInteraction = playerInteraction;
			_gameControl = gameControl;
		}

		public Dictionary<char, string> MainMenu { get; set; }
		public string ChoosedMenu { get; set; }
		public char PressedKey { get; set; }

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
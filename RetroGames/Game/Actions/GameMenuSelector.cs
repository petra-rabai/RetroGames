using RetroGames.Person.Actions;
using System;
using System.Collections.Generic;

namespace RetroGames.Game.Actions
{
	public class GameMenuSelector : IGameMenuSelector
	{
		private readonly IPlayerInteraction _playerInteraction;
		private readonly IGameMenu _gameMenu;

		public GameMenuSelector(IPlayerInteraction playerInteraction,
							IGameMenu gameMenu)
		{
			_gameMenu = gameMenu;
			_playerInteraction = playerInteraction;
		}

		public Dictionary<char, string> MainMenu { get; set; }
		public string ChoosedMenu { get; set; }
		public char PressedKey { get; set; }

		private char SetChoosedMenuKey()
		{
			PressedKey = SetPlayerPressedKey();

			return PressedKey;
		}

		public void SelectMenu()
		{
			MainMenu = GetMainMenu();
			PressedKey = SetChoosedMenuKey();
			ChoosedMenu = SetChoosedMenuFromGameMenu();
		}


		private Dictionary<char, string> GetMainMenu()
		{
			MainMenu = _gameMenu.MainMenu;

			return MainMenu;
		}

		private char SetPlayerPressedKey()
		{
			PressedKey = _playerInteraction.ReadPlayerKeyFromConsole();

			return PressedKey;
		}

		private string SetChoosedMenuFromGameMenu()
		{
			ChoosedMenu = MainMenu[PressedKey];

			return ChoosedMenu;
		}
	}
}
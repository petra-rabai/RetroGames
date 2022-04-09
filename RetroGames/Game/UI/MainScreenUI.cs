using System;
using System.Collections.Generic;

namespace RetroGames.Games.UI
{
	public class MainScreenUI : IMainScreenUI
	{
		private IGameMenu _gameMenu;

		public MainScreenUI(IGameMenu gameMenu)
		{
			_gameMenu = gameMenu;
		}

		public void InitializeMainScreenUI()
		{
			GameTitleUIToConsole();
			GameDescriptionUIToConsole();
			GameMenuUIToConsole();
		}

		private void GameTitleUIToConsole()
		{
			Console.Clear();
			Console.WriteLine("\n");
			Console.WriteLine("\t*****************************************************************");
			Console.WriteLine("\t*                                                               *");
			Console.WriteLine("\t******************                       ************************");
			Console.WriteLine("\t*                                                               *");
			Console.WriteLine("\t****************** RETRO GAME COLLECTION ************************");
			Console.WriteLine("\t*                                                               *");
			Console.WriteLine("\t******************                       ************************");
			Console.WriteLine("\t*                                                               *");
			Console.WriteLine("\t*****************************************************************");
		}

		private void GameDescriptionUIToConsole()
		{
			Console.WriteLine("\n");
			Console.WriteLine("\t*****************************************************************");
			Console.WriteLine("\n");
			Console.WriteLine("\t*******   You can play with retro games in The Console    *******");
			Console.WriteLine("\n");
			Console.WriteLine("\t*****************************************************************");
		}

		private void GameMenuUIToConsole()
		{
			Console.WriteLine("\n");
			Console.WriteLine("\t*****************************************************************");
			Console.WriteLine("\t*****************************************************************");
			Console.WriteLine("\n");
			Console.WriteLine("\t                     *** GAME MENU ***                           ");
			Console.WriteLine("\n");
			Console.WriteLine("\t*****************************************************************");
			Console.WriteLine("\t*****************************************************************");
			Console.WriteLine("\n");
			InitializeMainMenuToConsole();
			Console.WriteLine("\n");
			Console.WriteLine("\t                   *** Choose an option \n                        ");
			Console.WriteLine("\t*****************************************************************\n");
		}

		private void InitializeMainMenuToConsole()
		{
			foreach (KeyValuePair<char, string> menu in _gameMenu.MainMenu)
			{
				Console.WriteLine("\t\t\t" + " ** " + menu.Value + " - " + menu.Key + " key **" + "\n");
			}
		}
	}
}
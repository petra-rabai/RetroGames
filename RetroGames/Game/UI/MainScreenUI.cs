using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class MainScreenUI
	{
		
		public void InitializeMainScreenUI(GameMenu gameMenu)
		{
			GameTitleUIToConsole();
			GameDescriptionUIToConsole();
			GameMenuUIToConsole(gameMenu);

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

		private void GameMenuUIToConsole(GameMenu gameMenu)
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
			InitializeMainMenuToConsole(gameMenu);
			Console.WriteLine("\n");
			Console.WriteLine("\t                   *** Choose an option \n                        ");
			Console.WriteLine("\t*****************************************************************\n");
		}

		private void InitializeMainMenuToConsole(GameMenu gameMenu)
		{
			foreach (KeyValuePair<char, string> menu in gameMenu.MainMenu)
			{
				Console.WriteLine("\t\t\t" + " ** " + menu.Value + " - " + menu.Key + " key **" + "\n");
			}

		}



	}
}

using RetroGames.Game;
using RetroGames.Game.Actions;
using System;

namespace RetroGames
{
	public class Application : IApplication
	{
		private IScreen _screen;
		private IGameMenuNavigation _gameMenuNavigation;

		public Application(IScreen screen,IGameMenuNavigation gameMenuNavigation)
		{
			_screen = screen;
			_gameMenuNavigation = gameMenuNavigation;
			
		}

		public void Run()
		{
			_screen.MainScreenInitialize();
			_gameMenuNavigation.MenuNavigation();

		}


	}
}
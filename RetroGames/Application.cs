using RetroGames.Game;
using RetroGames.Game.Actions;
using System;

namespace RetroGames
{
	public class Application : IApplication
	{
		private IScreen _screen;
		private IGameMenuSelector _gameMenuNavigation;

		public Application(IScreen screen,IGameMenuSelector gameMenuNavigation)
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
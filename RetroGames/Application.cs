using RetroGames.Game;
using RetroGames.Game.Actions;
using System;

namespace RetroGames
{
	public class Application : IApplication
	{
		private IScreen _screen;

		public Application(IScreen screen)
		{
			_screen = screen;
			
		}

		public void Run()
		{
			_screen.MainScreenInitialize();
		}


	}
}
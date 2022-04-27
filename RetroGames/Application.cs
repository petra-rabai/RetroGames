using RetroGames.Game;
using RetroGames.Game.Actions;
using System;

namespace RetroGames
{
	public class Application : IApplication
	{
		private IScreen _screen;
		private IGameControl _gameControl;

		public Application(IScreen screen, IGameControl gameControl)
		{
			_screen = screen;
			_gameControl = gameControl;
		}

		public void Run()
		{
			_screen.MainScreenInitialize();
			_gameControl.Start();

		}


	}
}
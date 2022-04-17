using RetroGames.Game;
using RetroGames.Game.Actions;
using System;

namespace RetroGames
{
	public class Application : IApplication
	{
		private IMainScreen _mainScreen;

		public Application(IMainScreen mainScreen)
		{
			_mainScreen = mainScreen;
			
		}

		public void Run()
		{
			_mainScreen.MainScreenInitialize();
		}

		public void Close()
		{
			_mainScreen.MainScreenExit();
		}

	}
}
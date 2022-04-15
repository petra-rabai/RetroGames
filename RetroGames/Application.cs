using RetroGames.Game;

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
	}
}
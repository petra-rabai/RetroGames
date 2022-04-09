namespace RetroGames
{
	public class Application : IApplication
	{
		IMainScreen _mainScreen;
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

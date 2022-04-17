namespace RetroGames.Game
{
	public interface IMainScreen
	{
		bool WaitForUserPromptDisplayed { get; set; }

		void MainScreenInitialize();

		void MainScreenExit();

		bool WaitForInputSuccess();
	}
}
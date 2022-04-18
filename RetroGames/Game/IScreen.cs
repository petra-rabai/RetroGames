namespace RetroGames.Game
{
	public interface IScreen
	{
		bool WaitForUserPromptDisplayed { get; set; }

		void MainScreenInitialize();

		void MainScreenExit();
		void ScreenInitialize();

		bool WaitForInputSuccess();
	}
}
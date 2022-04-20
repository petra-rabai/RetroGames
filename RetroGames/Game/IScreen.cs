namespace RetroGames.Game
{
	public interface IScreen
	{
		bool WaitForUserPromptDisplayed { get; set; }

		void MainScreenInitialize();

		void ScreenInitialize();

		bool WaitForInputSuccess();
	}
}
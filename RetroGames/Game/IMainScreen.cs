namespace RetroGames
{
	public interface IMainScreen
	{
		bool WaitForUserPromptDisplayed { get; set; }

		void MainScreenInitialize();

		bool WaitForInputSuccess();
	}
}
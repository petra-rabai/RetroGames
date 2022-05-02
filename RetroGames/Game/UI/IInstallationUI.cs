namespace RetroGames.Game.UI
{
	public interface IInstallationUi
	{
		void HddListUi(int key, string driveName);

		void InstallationUiInitialize();

		void Wait();
	}
}
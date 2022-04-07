namespace RetroGames
{
	public interface IInstallation
	{
		bool IsInstallationSuccess { get; set; }
		void InstallationProcess();
	}
}
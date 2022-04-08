namespace RetroGames
{
	public interface IInstallation
	{
		bool IsInstallationSuccess { get; set; }
		string GameFilePath { get; set; }
		string UserFilePath { get; set; }
		string LogFilePath { get; set; }

		void InstallationProcess();

		bool CheckInstallationSuccess();
	}
}
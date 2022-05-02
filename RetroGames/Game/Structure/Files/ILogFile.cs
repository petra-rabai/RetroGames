namespace RetroGames.Game.Structure.Files
{
	public interface ILogFile
	{
		string LogFilePath { get; set; }

		void CreateLogFolder();
	}
}
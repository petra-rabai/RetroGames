namespace RetroGames.Game.Structure.Folders
{
	public interface ILogFolder
	{
		string LogFolderPath { get; set; }

		void CreateLogFolder();
	}
}
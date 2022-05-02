namespace RetroGames.Game.Structure.Folders
{
	public interface IGameFolder
	{
		string GameFolderPath { get; set; }

		void CreateGameFolder();
	}
}
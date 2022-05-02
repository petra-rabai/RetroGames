namespace RetroGames.Game.Structure.Files
{
	public interface IGameFile
	{
		string GameFilePath { get; set; }

		void CreateGameFile();
	}
}
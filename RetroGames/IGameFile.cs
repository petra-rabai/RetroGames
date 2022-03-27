namespace RetroGames
{
	public interface IGameFile
	{
		string GameFilePath { get; set; }
		bool IsGameFileExist { get; set; }
	}
}
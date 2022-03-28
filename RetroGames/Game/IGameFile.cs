namespace RetroGames
{
	public interface IGameFile
	{
		string GameFilePath { get; set; }
		string UserFilePath { get; set; }
		string LogFilePath { get; set; }
	}
}
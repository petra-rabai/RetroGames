namespace RetroGames
{
	public interface IGameDirectory
	{
		string GameDirectoryPath { get; set; }
		bool IsGameDirectoryExist { get; set; }
	}
}
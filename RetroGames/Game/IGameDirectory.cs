namespace RetroGames
{
	public interface IGameDirectory
	{
		string GameDirectoryPath { get; set; }
		string UserDirectoryPath { get; set; }
		string LogDirectoryPath { get; set; }
	}
}
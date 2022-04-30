namespace RetroGames.Game.DirectoryStructure
{
	public interface IGameDirectory
	{
		string GameDirectoryPath { get; set; }
		string UserDirectoryPath { get; set; }
		string LogDirectoryPath { get; set; }

		bool CheckGameDirectoriesExist();

	}
}
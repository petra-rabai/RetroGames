namespace RetroGames.Game.DirectoryStructure
{
	public interface IGameFile
	{
		string GameFilePath { get; set; }
		string UserFilePath { get; set; }
		string LogFilePath { get; set; }

		bool CheckGameFilesCreated();

		void CreateGameFiles();
	}
}
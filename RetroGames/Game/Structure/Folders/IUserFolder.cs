namespace RetroGames.Game.Structure.Folders
{
	public interface IUserFolder
	{
		string UserFolderPath { get; set; }

		void CreateUserFolder();
	}
}
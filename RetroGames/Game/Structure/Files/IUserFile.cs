namespace RetroGames.Game.Structure.Files
{
	public interface IUserFile
	{
		string UserFilePath { get; set; }

		void CreateUserFile();
	}
}
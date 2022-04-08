namespace RetroGames
{
	public interface IPlayer
	{
		string PlayerPassword { get; set; }
		bool IsRegistered { get; set; }
		bool IsLoggedIn { get; set; }
		string LoginName { get; set; }

	}
}
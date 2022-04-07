namespace RetroGames
{
	public interface IPlayer
	{
		char PressedKey { get; set; }
		string PlayerPassword { get; set; }
		bool IsRegistered { get; set; }
		bool IsLoggedIn { get; set; }
		string LoginName { get; set; }

		char GetPlayerKeyFromConsole();
	}
}
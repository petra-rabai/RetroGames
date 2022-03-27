namespace RetroGames
{
	public interface IPlayer
	{
		char PressedKey { get; set; }

		char GetPlayerKeyFromConsole();
	}
}
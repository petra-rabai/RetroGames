namespace RetroGames
{
	public interface IPlayerInteraction
	{
		char PressedKey { get; set; }

		char GetPlayerKeyFromConsole();
	}
}
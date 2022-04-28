namespace RetroGames.Person.Actions
{
	public interface IPlayerInteraction
	{
		char PressedKey { get; set; }
		string Email { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
		string LoginName { get; set; }

		char ReadPlayerKeyFromConsole();

		string ReadPlayerFirstNameFromConsole();

		string ReadPlayerLastNameFromConsole();

		string ReadPlayerLoginNameFromConsole();

		string GetPlayerEmailFromConsole();
	}
}
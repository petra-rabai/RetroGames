namespace RetroGames.Person.Actions
{
	public interface IPasswordHandler
	{
		bool IsPasswordEncrypted { get; set; }
		bool IsPasswordValid { get; set; }
		bool PasswordHandlingSuccess { get; set; }
		string PlayerPassword { get; set; }

		bool CheckPasswordHandling(string password);

		string GetPlayerPassword();
	}
}
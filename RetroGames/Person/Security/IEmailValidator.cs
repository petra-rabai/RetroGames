namespace RetroGames.Person.Security
{
	public interface IEmailValidator
	{
		bool IsEmailValid { get; set; }

		bool ValidateEmail(string email);
	}
}
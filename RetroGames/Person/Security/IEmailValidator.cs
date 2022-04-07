namespace RetroGames
{
	public interface IEmailValidator
	{
		bool IsEmailValid { get; set; }
		bool ValidateEmail(string email);


	}
}
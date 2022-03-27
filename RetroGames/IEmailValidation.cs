namespace RetroGames
{
	public interface IEmailValidation
	{
		string Email { get; set; }
		bool IsEmailValid { get; set; }

		string GetPlayerEmail();
	}
}
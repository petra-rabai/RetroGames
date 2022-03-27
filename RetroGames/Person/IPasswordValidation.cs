using System.Security;

namespace RetroGames
{
	public interface IPasswordValidation
	{
		bool IsPasswordValid { get; set; }
		string Password { get; set; }
		string GetPlayerPassword();

	}
}
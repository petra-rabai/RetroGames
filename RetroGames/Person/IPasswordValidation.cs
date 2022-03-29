using System.Security;

namespace RetroGames
{
	public interface IPasswordValidation
	{
		bool IsPasswordValid { get; set; }
		string PasswordError { get; set; }

	}
}
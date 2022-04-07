using System.Security;

namespace RetroGames
{
	public interface IPasswordValidator
	{
		bool IsPasswordValid { get; set; }
		string PasswordError { get; set; }

		bool ValidatePassword(string playerPassword);
	}
}
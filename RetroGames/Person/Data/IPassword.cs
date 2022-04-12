using System.Security;

namespace RetroGames
{
	public interface IPassword
	{
		string PlayerPassword { get; set; }

		string GetPlayerPassword();

		SecureString ConvertPasswordToSecure();
	}
}
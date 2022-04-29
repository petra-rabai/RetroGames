using System.Security;

namespace RetroGames.Person.Data
{
	public interface IPassword
	{
		string PlayerPassword { get; set; }

		string SetPlayerPassword();

	}
}
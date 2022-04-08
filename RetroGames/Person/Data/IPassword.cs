namespace RetroGames
{
	public interface IPassword
	{
		string PlayerPassword { get; set; }

		string GetPlayerPassword();
	}
}
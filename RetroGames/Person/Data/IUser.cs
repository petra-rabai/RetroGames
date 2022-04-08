namespace RetroGames
{
	public interface IUser
	{
		string FirstName { get; set; }
		string LastName { get; set; }
		string LoginName { get; set; }

		string GetPlayerFirstName();

		string GetPlayerLastName();

		string GetPlayerLoginName();
	}
}
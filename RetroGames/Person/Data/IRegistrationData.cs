namespace RetroGames.Person.Data
{
	public interface IRegistrationData
	{
		string Email { get; set; }
		string LoginName { get; set; }
		string Name { get; set; }
		string Password { get; set; }
	}
}
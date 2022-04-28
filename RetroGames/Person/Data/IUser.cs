namespace RetroGames.Person.Data
{
	public interface IUser
	{
		string FirstName { get; set; }
		string LastName { get; set; }
		string LoginName { get; set; }

		void CreateUser();
	}
}
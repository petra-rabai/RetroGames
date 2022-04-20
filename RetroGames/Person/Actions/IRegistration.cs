namespace RetroGames.Person.Actions
{
	public interface IRegistration
	{
		bool IsRegistered { get; set; }

		bool IsUserRegistered(bool registrationSuccess);

		void Start();
	}
}
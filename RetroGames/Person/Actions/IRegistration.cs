namespace RetroGames
{
	public interface IRegistration
	{
		bool IsRegistered { get; set; }
		bool IsUserRegistered(bool registrationSuccess);
		void UserRegistration();
	}
}
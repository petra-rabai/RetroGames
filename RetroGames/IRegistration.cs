namespace RetroGames
{
	public interface IRegistration
	{
		bool IsRegistered { get; set; }
		bool RegistrationSuccess(GameFile gameFile);
	}
}
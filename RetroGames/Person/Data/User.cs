using RetroGames.Person.Actions;

namespace RetroGames.Person.Data
{
	public class User : IUser
	{
		private readonly IPlayerInteraction _playerInteraction;
		private string _firstName;
		private string _lastName;
		private string _loginName;

		public User(IPlayerInteraction playerInteraction)
		{
			_playerInteraction = playerInteraction;
			_firstName = string.Empty;
			_lastName = string.Empty;
			_loginName = string.Empty;
			
		}

		public string FirstName { get; set; } = "";
		public string LastName { get; set; } = "";
		public string LoginName { get; set; } = "";


		public void CreateUser()
		{
			FirstName = SetPlayerFirstName();
			LastName = SetPlayerLastName(); 
			LoginName = SetPlayerLoginName();
		}

		private string SetPlayerFirstName()
		{
			_firstName = _playerInteraction.ReadPlayerFirstNameFromConsole();

			return _firstName;
		}

		private string SetPlayerLastName()
		{
			_lastName = _playerInteraction.ReadPlayerLastNameFromConsole();

			return _lastName;
		}

		private string SetPlayerLoginName()
		{
			_loginName = _playerInteraction.ReadPlayerLoginNameFromConsole();

			return _loginName;
		}
	}
}
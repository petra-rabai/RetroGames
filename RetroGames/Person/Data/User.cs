using System;
using RetroGames.Person.Actions;

namespace RetroGames.Person.Data
{
	public class User : IUser
	{
		private readonly IPlayerInteraction _playerInteraction;

		public User(IPlayerInteraction playerInteraction)
		{
			_playerInteraction = playerInteraction;
		}
		public string FirstName { get; set; } = "";
		public string LastName { get; set; } = "";
		public string LoginName { get; set; } = "";

		public string GetPlayerFirstName()
		{
			string firstName = _playerInteraction.GetPlayerFirstNameFromConsole();

			FirstName = firstName;

			return FirstName;
		}

		public string GetPlayerLastName()
		{
			string lastName = _playerInteraction.GetPlayerLastNameFromConsole();

			LastName = lastName;

			return LastName;
		}

		public string GetPlayerLoginName()
		{
			string loginName = _playerInteraction.GetPlayerLoginNameFromConsole();

			LoginName = loginName;

			return LoginName;
		}
	}
}
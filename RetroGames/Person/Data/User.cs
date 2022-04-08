using System;

namespace RetroGames
{
	public class User : IUser
	{
		public string FirstName { get; set; } = "";
		public string LastName { get; set; } = "";
		public string LoginName { get; set; } = "";

		public string GetPlayerFirstName()
		{
			string firstName = Console.ReadLine();

			FirstName = firstName;

			return FirstName;
		}

		public string GetPlayerLastName()
		{
			string lastName = Console.ReadLine();

			LastName = lastName;

			return LastName;
		}

		public string GetPlayerLoginName()
		{
			string loginName = Console.ReadLine();

			LoginName = loginName;

			return LoginName;
		}
	}
}
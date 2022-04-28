using System;
using System.Linq;

namespace RetroGames.Person.Actions
{
	public class PlayerInteraction : IPlayerInteraction
	{
		public char PressedKey { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; } = "";
		public string LastName { get; set; } = "";
		public string LoginName { get; set; } = "";

		public char ReadPlayerKeyFromConsole()
		{
			ConsoleKeyInfo hitkey = Console.ReadKey();

			if (hitkey.Key == ConsoleKey.D0
				|| hitkey.Key == ConsoleKey.D1
				|| hitkey.Key == ConsoleKey.D2
				|| hitkey.Key == ConsoleKey.D3
				|| hitkey.Key == ConsoleKey.D4
				|| hitkey.Key == ConsoleKey.D5)
			{
				string numKey = hitkey.Key.ToString();
				string[] numKeyValue = new string[1];
				numKeyValue[0] = numKey.Split('D').Last();
				PressedKey = Convert.ToChar(numKeyValue[0]);
			}
			else
			{
				PressedKey = Char.Parse(hitkey.Key.ToString());
			}
			return PressedKey;
		}

		public string GetPlayerEmailFromConsole()
		{
			string email = Console.ReadLine();

			if (email != null) Email = email.Trim();

			return Email;
		}

		public string ReadPlayerFirstNameFromConsole()
		{
			string firstName = Console.ReadLine();

			if (firstName != null) FirstName = firstName.Trim();

			return FirstName;
		}

		public string ReadPlayerLastNameFromConsole()
		{
			string lastName = Console.ReadLine();

			if (lastName != null) LastName = lastName.Trim();

			return LastName;
		}

		public string ReadPlayerLoginNameFromConsole()
		{
			string loginName = Console.ReadLine();

			if (loginName != null) LoginName = loginName.Trim();

			return LoginName;
		}
	}
}
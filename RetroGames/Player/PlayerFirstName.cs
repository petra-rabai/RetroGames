using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Player
{
	public class PlayerFirstName
	{
		public string FirstName { get; set; } = "";

		public string GetPlayerFirstName()
		{
			string firstName = Console.ReadLine();

			FirstName = firstName;

			return FirstName;
		}
	}
}

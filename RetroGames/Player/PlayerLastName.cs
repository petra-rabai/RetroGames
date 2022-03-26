using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Player
{
	public class PlayerLastName
	{
		public string LastName { get; set; } = "";

		public string GetPlayerLastName()
		{
			string lastName = Console.ReadLine();

			LastName = lastName;

			return LastName;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Player
{
	public class PlayerLoginName
	{
		public string LoginName { get; set; } = "";

		public string GetPlayerLoginName()
		{
			string loginName = Console.ReadLine();

			LoginName = loginName;

			return LoginName;
		}
	}
}

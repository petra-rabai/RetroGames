using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class GameMenu : IGameMenu
	{
		public Dictionary<char, string> MainMenu { get; set; } = new Dictionary<char, string>()
		{
			['N'] = "New Game",
			['I'] = "Installation",
			['P'] = "Pause Game",
			['S'] = "Save Game",
			['D'] = "Load Game",
			['L'] = "Login",
			['R'] = "Registration",
			['H'] = "Help",
			['Q'] = "Quit"
		};

	}
}

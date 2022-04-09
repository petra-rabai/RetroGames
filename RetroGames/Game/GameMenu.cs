using System.Collections.Generic;

namespace RetroGames.Games
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
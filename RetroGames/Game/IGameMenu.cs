using System.Collections.Generic;

namespace RetroGames
{
	public interface IGameMenu
	{
		Dictionary<char, string> MainMenu { get; set; }
	}
}
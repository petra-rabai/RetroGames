using System.Collections.Generic;

namespace RetroGames.Game
{
	public interface IGameMenu
	{
		Dictionary<char, string> MainMenu { get; set; }
	}
}
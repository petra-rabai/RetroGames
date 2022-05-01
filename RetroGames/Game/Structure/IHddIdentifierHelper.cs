using System.Collections.Generic;

namespace RetroGames.Game.Structure
{
	public interface IHddIdentifierHelper
	{
		Dictionary<int, string> HddList { get; set; }

		void GetHddListFromAvailableHdds();
	}
}
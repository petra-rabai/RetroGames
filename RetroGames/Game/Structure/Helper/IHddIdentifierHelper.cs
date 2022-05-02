using System.Collections.Generic;

namespace RetroGames.Game.Structure.Helper
{
	public interface IHddIdentifierHelper
	{
		Dictionary<int, string> HddList { get; set; }

		void GetHddListFromAvailableHdds();
		void EreaseHddList();
	}
}
using System.Collections.Generic;

namespace RetroGames.Game.Structure.Hdd
{
	public interface IHddIdentifierHelper
	{
		Dictionary<int, string> HddList { get; set; }

		void GetHddListFromAvailableHdds();
	}
}
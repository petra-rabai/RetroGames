using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Game.Structure
{
	public class HddIdentifierHelper : IHddIdentifierHelper
	{
		private readonly IAvailableHdds _availableHdds;

		public HddIdentifierHelper(IAvailableHdds availableHdds)
		{
			_availableHdds = availableHdds;
		}
		private string[] _availabelHddList;
		public Dictionary<int, string> HddList { get; set; }

		public void GetHddListFromAvailableHdds()
		{
			_availabelHddList = GetAvailableHddList();

			HddList = LoadHddListFromAvailableDrives();
		}

		private string[] GetAvailableHddList()
		{
			_availabelHddList = _availableHdds.GetAvailableHddListFromHddInfo();

			return _availabelHddList;
		}

		private Dictionary<int, string> LoadHddListFromAvailableDrives()
		{
			for (int i = 0; i < _availabelHddList.Length; i++)
			{
				HddList.Add(i, _availabelHddList[i]);
			}

			return HddList;
		}
	}
}

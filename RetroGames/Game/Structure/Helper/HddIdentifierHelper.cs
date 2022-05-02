using RetroGames.Game.Structure.Hdd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Game.Structure.Helper
{
	public class HddIdentifierHelper : IHddIdentifierHelper
	{
		private readonly IAvailableHdds _availableHdds;

		public HddIdentifierHelper(IAvailableHdds availableHdds)
		{
			_availableHdds = availableHdds;
		}
		private string[] _availabelHddList;
		public Dictionary<int, string> HddList { get; set; } = new();

		public void GetHddListFromAvailableHdds()
		{
			_availabelHddList = GetAvailableHddList();

			HddList = LoadHddListFromAvailableDrives();
		}
		public void EreaseHddList()
		{
			for (int i = HddList.Count; i >= 0; i--)
			{
				HddList.Remove(i);
			}
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

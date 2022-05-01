using RetroGames.Person.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Game.Structure.Hdd
{
	public class InstallationHdd : IInstallationHdd
	{
		private readonly IDefaultHdd _defaultHdd;
		private readonly IHddIdentifierHelper _hddIdentifierHelper;
		private readonly IPlayerInteraction _playerInteraction;

		public InstallationHdd(IDefaultHdd defaultHdd, IPlayerInteraction playerInteraction, IHddIdentifierHelper hddIdentifierHelper)
		{
			_defaultHdd = defaultHdd;
			_playerInteraction = playerInteraction;
			_hddIdentifierHelper = hddIdentifierHelper;
		}

		private string _hddName;
		private char _playerDecision;
		public string HddName { get; set; }

		public void GetInstallationHddName()
		{
			_defaultHdd.GetDefaultHddFromAvailableHdd();

			HddName = SelectHddNameBasedonPlayerDecesion(_defaultHdd.HddCount);
		}

		private string SelectHddNameBasedonPlayerDecesion(int hddCount)
		{
			_hddIdentifierHelper.GetHddListFromAvailableHdds();
			_playerDecision = GetPlayerDecesion();

			if (hddCount == 1 || _playerDecision == '*')
			{
				_hddName = _defaultHdd.DefaultHddName;
			}
			else
			{
				int hddListKey = Convert.ToInt32(_playerDecision.ToString());
				_hddName = _hddIdentifierHelper.HddList[hddListKey];
			}

			return _hddName;
		}

		private char GetPlayerDecesion()
		{
			_playerDecision = _playerInteraction.ReadPlayerKeyFromConsole();

			return _playerDecision;
		}

	}
}

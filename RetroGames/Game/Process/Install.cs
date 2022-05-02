using RetroGames.Game.Actions;
using RetroGames.Game.Structure.Hdd;
using RetroGames.Game.Structure.Helper;
using RetroGames.Game.UI;
using RetroGames.Person.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Game.Process
{
	public class Install : IInstall
	{
		private readonly IInstallationUi _installationUi;
		private readonly IInstallation _installation;
		private readonly IInstallationHdd _installationHdd;
		private readonly IHddIdentifierHelper _hddIdentifierHelper;

		public Install(IInstallationUi installationUi, IInstallation installation, IInstallationHdd installationHdd, IHddIdentifierHelper hddIdentifierHelper)
		{
			_installationUi = installationUi;
			_installation = installation;
			_installationHdd = installationHdd;
			_hddIdentifierHelper = hddIdentifierHelper;
		}

		public void Initialize()
		{
			_installationUi.InstallationUiInitialize();
			WriteHddListForUi();
			_installationUi.Wait();
			_hddIdentifierHelper.EreaseHddList();
			ReadInstallationHddNameFromPlayer();
			_installation.Start();
		}

		private void ReadInstallationHddNameFromPlayer()
		{
			_installationHdd.GetInstallationHddName();
		}

		
		private void WriteHddListForUi()
		{
			int key;
			string hddName;
			Dictionary<int, string> hddList;

			_hddIdentifierHelper.GetHddListFromAvailableHdds();
			hddList = _hddIdentifierHelper.HddList;

			foreach (KeyValuePair<int, string> choosedHdd in hddList)
			{
				key = choosedHdd.Key;
				hddName = choosedHdd.Value;
				_installationUi.HddListUi(key, hddName);
			}
		}

	}
}

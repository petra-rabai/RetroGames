using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Game.Structure
{
	public class AvailableHdds : IAvailableHdds
	{
		private readonly IHddInfo _hddInfo;

		public AvailableHdds(IHddInfo hddInfo)
		{
			_hddInfo = hddInfo;
		}
		private const int _gbConvert = (1024 * 1024 * 1024);
		private string[] _availablehdds;
		private long[] _availableFreeHddSpace;

		private int _hddCount;

		public string[] AvailableHddList { get; set; }
		public long[] AvailableFreeHddSpace { get; set; }

		public string[] GetAvailableHddListFromHddInfo()
		{
			GetInformationFromHddInfo();

			AvailableHddList = CollectAvailableDisks();

			return AvailableHddList;
		}

		private void GetInfoFromHddInfo()
		{
			_hddInfo.GetHddInformation();
		}

		public long[] GetAvailableFreeHddSpaceFromHddInfo()
		{
			GetInformationFromHddInfo();

			AvailableFreeHddSpace = GetAvailableFreeSpace(_hddCount);

			return AvailableFreeHddSpace;
		}

		private void GetInformationFromHddInfo()
		{
			GetInfoFromHddInfo();
			_hddCount = GetHddCountFromHddInfo();
		}

		private long[] GetAvailableFreeSpace(int driveCount)
		{
			_availableFreeHddSpace = new long[driveCount];

			for (int i = 0; i < driveCount; i++)
			{
				_availableFreeHddSpace[i] = _hddInfo.HddInformation[i].AvailableFreeSpace / _gbConvert;
			}

			return _availableFreeHddSpace;
		}


		private int GetHddCountFromHddInfo()
		{
			_hddCount = _hddInfo.HddInformation.Length;

			return _hddCount;
		}

		private string[] CollectAvailableDisks()
		{
			_availablehdds = new string[_hddCount];

			for (int i = 0; i < _hddCount; i++)
			{
				_availablehdds[i] = _hddInfo.HddInformation[i].Name;
			}

			return _availablehdds;
		}


	}
}

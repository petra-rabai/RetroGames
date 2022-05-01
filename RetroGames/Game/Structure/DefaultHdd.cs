using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Game.Structure
{
	public class DefaultHdd : IDefaultHdd
	{
		private readonly IAvailableHdds _availableHdds;

		public DefaultHdd(IAvailableHdds availableHdds)
		{
			_availableHdds = availableHdds;
		}

		private long[] _availableFreeSpace;
		private string[] _hddName;
		private double[] _compareableSpace;
		private string _defaultHdd;
		public string DefaultHddName { get; set; }
		public int HddCount { get; set; }

		public void GetDefaultHddFromAvailableHdd()
		{
			GetInformationFromAvailableHdd();

			HddCount = _availableHdds.AvailableHddList.Length;
			_availableFreeSpace = _availableHdds.AvailableFreeHddSpace;
			_hddName = _availableHdds.AvailableHddList;

			DefaultHddName = CompareDisksSpace(HddCount, _availableFreeSpace, _hddName);
		}

		private void GetInformationFromAvailableHdd()
		{
			_availableHdds.GetAvailableHddListFromHddInfo();
			_availableHdds.GetAvailableFreeHddSpaceFromHddInfo();
		}

		private string CompareDisksSpace(int driveCount, long[] availableFreeSpace, string[] driveName)
		{
			_compareableSpace = new double[driveCount];

			for (int i = 0; i < driveCount; i++)
			{
				_compareableSpace[i] = Convert.ToDouble(availableFreeSpace[i]);
			}

			for (int i = 0; i < driveCount; i++)
			{
				for (int j = driveCount - 1; j >= 0; j--)
				{
					if (_compareableSpace[i] > _compareableSpace[j])
					{
						_defaultHdd = driveName[i];
					}
					else
					{
						_defaultHdd = driveName[j];
					}
				}
			}

			return _defaultHdd;
		}



	}
}

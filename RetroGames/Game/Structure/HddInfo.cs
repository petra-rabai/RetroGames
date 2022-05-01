using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Game.Structure
{
	public class HddInfo : IHddInfo
	{
		private readonly IFileSystemHelper _fileSystemHelper;

		public HddInfo(IFileSystemHelper fileSystemHelper)
		{
			_fileSystemHelper = fileSystemHelper;
		}

		//private const int _gbConvert = (1024 * 1024 * 1024);
		private IDriveInfo[] _hddInfo;
		private IDriveInfoFactory _hddInfoFactory;

		public IDriveInfo[] HddInformation { get; set; }

		public IDriveInfo[] GetHddInformation()
		{
			HddInformation = SetHddInfo();

			return HddInformation;
		}

		//private Dictionary<int, string> LoadDriveListFromAvailableDrives()
		//{
		//	for (int i = 0; i < _availableDrives.Length; i++)
		//	{
		//		DriveList.Add(i, _availableDrives[i]);
		//	}

		//	return DriveList;
		//}

		private IDriveInfo[] SetHddInfo()
		{
			_hddInfoFactory = _fileSystemHelper.FileSystem.DriveInfo;

			_hddInfo = _hddInfoFactory.GetDrives();

			return _hddInfo;
		}

		//private string[] CollectAvailableDrives()
		//{
		//	_availableDrives = new string[_driveInfo.Length];

		//	for (int i = 0; i < _driveInfo.Length; i++)
		//	{
		//		_availableDrives[i] = _driveInfo[i].Name;
		//	}

		//	return _availableDrives;
		//}

	}

}

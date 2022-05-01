using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Game.Structure.Hdd
{
	public class HddInfo : IHddInfo
	{
		private readonly IFileSystemHelper _fileSystemHelper;

		public HddInfo(IFileSystemHelper fileSystemHelper)
		{
			_fileSystemHelper = fileSystemHelper;
		}

		private IDriveInfo[] _hddInfo;
		private IDriveInfoFactory _hddInfoFactory;

		public IDriveInfo[] HddInformation { get; set; }

		public IDriveInfo[] GetHddInformation()
		{
			HddInformation = SetHddInfo();

			return HddInformation;
		}

		private IDriveInfo[] SetHddInfo()
		{
			_hddInfoFactory = _fileSystemHelper.FileSystem.DriveInfo;

			_hddInfo = _hddInfoFactory.GetDrives();

			return _hddInfo;
		}

	}

}

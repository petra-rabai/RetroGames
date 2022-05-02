using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Abstractions;

namespace RetroGames.Game.Structure.Helper
{
	public class FileSystemHelper : IFileSystemHelper
	{

		public IFileSystem FileSystem { get; set; }

		public void FileSystemInit()
		{
			FileSystem = new FileSystem();
		}

	}
}

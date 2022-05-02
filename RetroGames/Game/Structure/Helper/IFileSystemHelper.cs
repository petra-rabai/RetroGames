using System.IO.Abstractions;

namespace RetroGames.Game.Structure.Helper
{
	public interface IFileSystemHelper
	{
		IFileSystem FileSystem { get;}
		void FileSystemInit();
	}
}
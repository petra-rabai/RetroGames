using System.IO.Abstractions;

namespace RetroGames.Game.Structure
{
	public interface IFileSystemHelper
	{
		IFileSystem FileSystem { get;}
		void FileSystemInit();
	}
}
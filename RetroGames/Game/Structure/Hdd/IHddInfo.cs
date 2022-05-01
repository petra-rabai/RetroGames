using System.IO.Abstractions;

namespace RetroGames.Game.Structure.Hdd
{
	public interface IHddInfo
	{
		IDriveInfo[] HddInformation { get; set; }

		IDriveInfo[] GetHddInformation();
	}
}
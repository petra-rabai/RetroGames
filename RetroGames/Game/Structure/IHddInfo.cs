using System.IO.Abstractions;

namespace RetroGames.Game.Structure
{
	public interface IHddInfo
	{
		IDriveInfo[] HddInformation { get; set; }

		IDriveInfo[] GetHddInformation();
	}
}
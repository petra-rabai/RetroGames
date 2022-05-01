namespace RetroGames.Game.Structure
{
	public interface IDefaultHdd
	{
		string DefaultHddName { get; set; }
		int HddCount { get; set; }
		void GetDefaultHddFromAvailableHdd();
	}
}
namespace RetroGames.Game.Structure.Hdd
{
	public interface IDefaultHdd
	{
		string DefaultHddName { get; set; }
		int HddCount { get; set; }
		void GetDefaultHddFromAvailableHdd();
	}
}
namespace RetroGames.Game.Structure.Hdd
{
	public interface IAvailableHdds
	{
		string[] AvailableHddList { get; set; }
		long[] AvailableFreeHddSpace { get; set; }

		string[] GetAvailableHddListFromHddInfo();

		long[] GetAvailableFreeHddSpaceFromHddInfo();

	}
}
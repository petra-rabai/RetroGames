using RetroGames.Game.Structure;

namespace RetroGames.Game.Actions
{
	public class Installation : IInstallation
	{
		private readonly IGameStructure _gameStructure;


		public Installation(IGameStructure gameStructure)
		{
			_gameStructure = gameStructure;
		}

		public void Start()
		{
			_gameStructure.Initialize();
		}

	}
}
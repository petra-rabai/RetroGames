namespace RetroGames.Game.Actions
{
	public interface IGameMenuNavigation
	{
		string ChoosedMenu { get; set; }
		bool isNavigationSuccess { get; set; }
		void MenuNavigation();
	}
}
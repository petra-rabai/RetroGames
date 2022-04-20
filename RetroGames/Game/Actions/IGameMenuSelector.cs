namespace RetroGames.Game.Actions
{
	public interface IGameMenuSelector
	{
		string ChoosedMenu { get; set; }
		void MenuNavigation();
	}
}
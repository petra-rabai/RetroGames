using RetroGames.Game.Actions;
using RetroGames.Game.Process;
using RetroGames.Person.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Game
{
	public class GameControl : IGameControl
	{
		private readonly IGameMenuSelector _gameMenuSelector;
		private readonly IInstall _install;
		private readonly ILogin _login;

		public GameControl(IGameMenuSelector gameMenuSelector, IInstall install, ILogin login)
		{
			_gameMenuSelector = gameMenuSelector;
			_install = install;
			_login = login;
		}

		string _choosedGameMenu;

		public void Start()
		{
			GetChoosedGameMenu();

			switch (_choosedGameMenu)
			{
				case "New Game":

					break;
				case "Installation":
					_install.Initialize();
					break;
				case "Registration":
					break;
				case "Login":
					_login.Start();
					break;
				case "Quit":
					End();
					break;
				default:
					break;
			}
		}

		private string GetChoosedGameMenu()
		{
			_gameMenuSelector.SelectMenu();
			_choosedGameMenu = _gameMenuSelector.ChoosedMenu;

			return _choosedGameMenu;
		}

		private void End()
		{
			Environment.Exit(1);
		}
	}
}

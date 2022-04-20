using RetroGames.Game.Actions;
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
		private readonly IInstallation _installation;
		private readonly IRegistration _registration;
		private readonly ILogin _login;

		public GameControl(IGameMenuSelector gameMenuSelector, IInstallation installation, IRegistration registration, ILogin login)
		{
			_gameMenuSelector = gameMenuSelector;
			_installation = installation;
			_registration = registration;
			_login = login;
		}

		string choosedGameMenu;

		public void Start()
		{
			GetChoosedGameMenu();

			switch (choosedGameMenu)
			{
				case "New Game":

					break;
				case "Installation":
					_installation.Start();
					break;
				case "Registration":
					_registration.Start();
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
			choosedGameMenu = _gameMenuSelector.ChoosedMenu;

			return choosedGameMenu;
		}

		private void End()
		{
			Environment.Exit(1);
		}
	}
}

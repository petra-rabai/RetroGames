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
		private readonly IGameMenuNavigation _gameMenuNavigation;
		private readonly IInstallation _installation;
		private readonly IRegistration _registration;

		public GameControl(IGameMenuNavigation gameMenuNavigation, IInstallation installation, IRegistration registration)
		{
			_gameMenuNavigation = gameMenuNavigation;
			_installation = installation;
			_registration = registration;
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
					_installation.InstallationProcess();
					break;
				case "Registration":
					_registration.UserRegistration();
					break;
				default:
					break;
			}
		}

		private string GetChoosedGameMenu()
		{
			choosedGameMenu = _gameMenuNavigation.ChoosedMenu;

			return choosedGameMenu;
		}
	}
}

﻿using RetroGames.Game.Actions;
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
		private readonly ILogin _login;

		public GameControl(IGameMenuSelector gameMenuSelector, IInstallation installation, ILogin login)
		{
			_gameMenuSelector = gameMenuSelector;
			_installation = installation;
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
					_installation.Start();
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
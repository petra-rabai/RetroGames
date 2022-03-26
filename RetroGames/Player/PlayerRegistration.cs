using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Player
{
	public class PlayerRegistration
	{
		public string Name { get; set; }
		public string LoginName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		public string GetPlayerName(PlayerFirstName playerFirstName, PlayerLastName playerLastName)
		{
			playerFirstName.GetPlayerFirstName();
			playerLastName.GetPlayerLastName();

			Name = playerFirstName.FirstName + playerLastName.LastName;

			return Name;
		}
		public string GetPlayerLoginName(PlayerLoginName playerLoginName)
		{
			playerLoginName.GetPlayerLoginName();
			
			LoginName = playerLoginName.LoginName;

			return LoginName;
		}

		public string GetPlayerPassword(PlayerPassword playerPassword)
		{
			playerPassword.GetPlayerPassword();

			Password = playerPassword.Password;

			return Password;
		}

		public string GetPlayerEmail(PlayerEmail playerEmail)
		{
			playerEmail.GetPlayerEmail();
			
			Email = playerEmail.Email;

			return Email;
		}

		public void Registration(PlayerFirstName playerFirstName,
						   PlayerLastName playerLastName,
						   PlayerLoginName playerLoginName,
						   PlayerPassword playerPassword,
						   PlayerEmail playerEmail)
		{
			Name = GetPlayerName(playerFirstName, playerLastName);
			LoginName = GetPlayerLoginName(playerLoginName);
			Password = GetPlayerPassword(playerPassword);
			Email = GetPlayerEmail(playerEmail);
		}
	}
}

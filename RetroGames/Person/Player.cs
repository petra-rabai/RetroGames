using RetroGames.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RetroGames
{
	public class Player : IPlayer
	{
		public string LoginName { get; set; }	
		public string PlayerPassword { get; set; }
		public bool IsRegistered { get; set; }
		public bool IsLoggedIn { get; set; }
		public char PressedKey { get; set; }
		User User { get; set; } = new User();
		Password Password { get; set; } = new Password();
		Registration Registration { get; set; } = new Registration();
		Login Login { get; set; } = new Login();

		public void GetLoginData()
		{
			GetPlayerLoginName();
			GetPlayerPassword();
		}
		
		
		private string GetPlayerLoginName()
		{
			LoginName = User.GetPlayerLoginName();

			return LoginName;
		}

		private string GetPlayerPassword()
		{
			PlayerPassword = Password.GetPlayerPassword();

			return PlayerPassword;
		}

		public void GetRegistrationIsSuccess()
		{
			RegistrationSuccess();
		}

		public void GetLoginIsSuccess()
		{
			LoginSuccess();
		}


		private bool RegistrationSuccess()
		{
			IsRegistered = Registration.IsRegistered;

			return IsRegistered;
		}

		private bool LoginSuccess()
		{
			IsLoggedIn = Login.IsLoggedIn;

			return IsRegistered;
		}

		public char GetPlayerKeyFromConsole()
		{
			ConsoleKeyInfo hitkey = Console.ReadKey();

			if (hitkey.Key == ConsoleKey.D0
				|| hitkey.Key == ConsoleKey.D1
				|| hitkey.Key == ConsoleKey.D2
				|| hitkey.Key == ConsoleKey.D3
				|| hitkey.Key == ConsoleKey.D4
				|| hitkey.Key == ConsoleKey.D5)
			{
				string numKey = hitkey.Key.ToString();
				string[] numKeyValue = new string[1];
				numKeyValue[0] = numKey.Split('D').Last();
				PressedKey = Convert.ToChar(numKeyValue[0]);
			}
			else
			{
				PressedKey = Char.Parse(hitkey.Key.ToString());
			}
			return PressedKey;
		}
	}
}

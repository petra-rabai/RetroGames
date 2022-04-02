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

		public void GetLoginData(User user, Password password,PasswordEncrypter passwordEncrypter, PasswordValidation passwordValidation)
		{
			LoginName = user.LoginName;
			PlayerPassword = password.PlayerPassword;

			CheckLoginDataNotEmpty(user,password,passwordEncrypter,passwordValidation);

		}

		private void CheckLoginDataNotEmpty(User user, Password password, PasswordEncrypter passwordEncrypter, PasswordValidation passwordValidation)
		{
			if (LoginName == "" || PlayerPassword == "")
			{
				GetPlayerLoginName(user);
				GetPlayerPassword(password,passwordEncrypter,passwordValidation);
			}
		}

		public void GetRegistrationIsSuccess(bool registred, Registration registration)
		{
			CheckRegistrationSuccess(registred, registration);
		}

		public void GetLoginIsSuccess(Login login)
		{
			CheckLoginSuccess(login);
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

		private string GetPlayerLoginName(User user)
		{
			LoginName = user.GetPlayerLoginName();
			
			return LoginName;
		}

		private string GetPlayerPassword(Password password, PasswordEncrypter passwordEncrypter, PasswordValidation passwordValidation)
		{
			PlayerPassword = password.GetPlayerPassword(passwordEncrypter,passwordValidation);
		
			return PlayerPassword;
		}

		private bool CheckRegistrationSuccess(bool registred, Registration registration)
		{
			registration.IsUserRegistered(registred);

			IsRegistered = registration.IsRegistered;

			return IsRegistered;
		}

		private bool CheckLoginSuccess(Login login)
		{
			IsLoggedIn = login.IsLoggedIn;

			return IsLoggedIn;
		}
		
	}
}

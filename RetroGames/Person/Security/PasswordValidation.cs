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
	public class PasswordValidation : IPasswordValidation, IPassword
	{
		public bool IsPasswordValid { get; set; } = false;
		public string PasswordError { get; set; }
		public string PlayerPassword { get; set; }

		Regex PasswordRegEx = new Regex(GameSettings.Default.PasswordRegEx);

		public bool ValidatePassword(string playerPassword)
		{
			GetPlayerPassword(playerPassword);
			
			if (PasswordRegEx.Match(PlayerPassword).Success)
			{
				IsPasswordValid = true;
			}
			else
			{
				IsPasswordValid = false;
				GetPasswordError();
			}
			
			return IsPasswordValid;
		}

		private string GetPasswordError()
		{
			if (!IsPasswordValid)
			{
				string passwordError = GetErrorReason();
				
				PasswordError = passwordError;
			}

			return PasswordError;
		}

		private string GetPlayerPassword(string playerPassword)
		{
			PlayerPassword = playerPassword;

			return PlayerPassword;
		}

		private string GetErrorReason()
		{
			Regex hasNumber = new Regex(@"[0-9]+");
			Regex hasUpperChar = new Regex(@"[A-Z]+");
			Regex hasMiniMaxChars = new Regex(@".{8,15}");
			Regex hasLowerChar = new Regex(@"[a-z]+");
			Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

			string Error="";

			if (!hasLowerChar.IsMatch(PlayerPassword))
			{
				Error = "Password should contain at least one lower case letter.";
			}
			if (!hasUpperChar.IsMatch(PlayerPassword))
			{
				Error = "Password should contain at least one upper case letter.";
			}
			if (!hasMiniMaxChars.IsMatch(PlayerPassword) || PlayerPassword.Length > 15)
			{
				Error = "Password should not be lesser than 8 or should not be greater than 15 characters.";
			}
			if (!hasNumber.IsMatch(PlayerPassword))
			{
				Error = "Password should contain at least one numeric value.";
			}
			if (!hasSymbols.IsMatch(PlayerPassword))
			{
				Error = "Password should contain at least one special case character.";
			}
			
			return Error;
		}

		









	}
}

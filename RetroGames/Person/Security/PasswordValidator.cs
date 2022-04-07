using RetroGames.Properties;
using System.Text.RegularExpressions;

namespace RetroGames
{
	public class PasswordValidator : IPasswordValidator
	{
		private const string hasNumberPattern = @"[0-9]+";
		private const string hasUpperCharPattern = @"[A-Z]+";
		private const string hasMinMaxCharPattern = @".{8,15}";
		private const string hasLowerCharPattern = @"[a-z]+";
		private const string hasSymbolsPattern = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]";
		
		private const string lowerCharError = "Password should contain at least one lower case letter.";
		private const string upperCharError = "Password should contain at least one upper case letter.";
		private const string minMaxCharError = "Password should not be lesser than 8 or should not be greater than 15 characters.";
		private const string numberError = "Password should contain at least one numeric value.";
		private const string symbolError = "Password should contain at least one special case character.";

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
			Regex hasNumber = new Regex(hasNumberPattern);
			Regex hasUpperChar = new Regex(hasUpperCharPattern);
			Regex hasMiniMaxChars = new Regex(hasMinMaxCharPattern);
			Regex hasLowerChar = new Regex(hasLowerCharPattern);
			Regex hasSymbols = new Regex(hasSymbolsPattern);

			string Error = "";

			if (!hasLowerChar.IsMatch(PlayerPassword))
			{
				Error = lowerCharError;
			}
			if (!hasUpperChar.IsMatch(PlayerPassword))
			{
				Error = upperCharError;
			}
			if (!hasMiniMaxChars.IsMatch(PlayerPassword) || PlayerPassword.Length > 15)
			{
				Error = minMaxCharError;
			}
			if (!hasNumber.IsMatch(PlayerPassword))
			{
				Error = numberError;
			}
			if (!hasSymbols.IsMatch(PlayerPassword))
			{
				Error = symbolError;
			}
			
			return Error;
		}

		









	}
}

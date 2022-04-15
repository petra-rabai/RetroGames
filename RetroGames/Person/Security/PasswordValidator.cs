using RetroGames.Properties;
using System.Text.RegularExpressions;

namespace RetroGames.Person.Security
{
	public class PasswordValidator : IPasswordValidator
	{
		private const string HasNumberPattern = @"[0-9]+";
		private const string HasUpperCharPattern = @"[A-Z]+";
		private const string HasMinMaxCharPattern = @".{8,15}";
		private const string HasLowerCharPattern = @"[a-z]+";
		private const string HasSymbolsPattern = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]";

		private const string LowerCharError = "Password should contain at least one lower case letter.";
		private const string UpperCharError = "Password should contain at least one upper case letter.";
		private const string MinMaxCharError = "Password should not be lesser than 8 or should not be greater than 15 characters.";
		private const string NumberError = "Password should contain at least one numeric value.";
		private const string SymbolError = "Password should contain at least one special case character.";

		public bool IsPasswordValid { get; set; }
		public string PasswordError { get; set; }
		public string PlayerPassword { get; set; }

		private Regex _passwordRegEx = new(GameSettings.Default.PasswordRegEx);

		public bool ValidatePassword(string playerPassword)
		{
			PlayerPassword = GetPlayerPassword(playerPassword);

			if (_passwordRegEx.Match(PlayerPassword).Success)
			{
				IsPasswordValid = true;
			}
			else
			{
				IsPasswordValid = false;
				PasswordError = GetPasswordError();
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
			Regex hasNumber = new(HasNumberPattern);
			Regex hasUpperChar = new(HasUpperCharPattern);
			Regex hasMiniMaxChars = new(HasMinMaxCharPattern);
			Regex hasLowerChar = new(HasLowerCharPattern);
			Regex hasSymbols = new(HasSymbolsPattern);

			string error = "";

			if (!hasLowerChar.IsMatch(PlayerPassword))
			{
				error = LowerCharError;
			}
			if (!hasUpperChar.IsMatch(PlayerPassword))
			{
				error = UpperCharError;
			}
			if (!hasMiniMaxChars.IsMatch(PlayerPassword) || PlayerPassword.Length > 15)
			{
				error = MinMaxCharError;
			}
			if (!hasNumber.IsMatch(PlayerPassword))
			{
				error = NumberError;
			}
			if (!hasSymbols.IsMatch(PlayerPassword))
			{
				error = SymbolError;
			}

			return error;
		}
	}
}
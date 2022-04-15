using RetroGames.Properties;
using System.Text.RegularExpressions;

namespace RetroGames.Person.Security
{
	public class EmailValidator : IEmailValidator
	{
		public bool IsEmailValid { get; set; }

		private Regex _emailRegEx = new(GameSettings.Default.EmailRegEx);

		public bool ValidateEmail(string email)
		{
			if (_emailRegEx.Match(email).Success)
			{
				IsEmailValid = true;
			}
			else
			{
				IsEmailValid = false;
			}

			return IsEmailValid;
		}
	}
}
using RetroGames.Properties;
using System.Text.RegularExpressions;

namespace RetroGames
{
	public class EmailValidator : IEmailValidator
	{
		public bool IsEmailValid { get; set; } = false;

		private Regex emailRegEx = new Regex(GameSettings.Default.EmailRegEx);

		public bool ValidateEmail(string email)
		{
			if (emailRegEx.Match(email).Success)
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
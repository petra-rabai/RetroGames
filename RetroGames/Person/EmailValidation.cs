using RetroGames.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RetroGames
{
	public class EmailValidation : IEmailValidation
	{
		public bool IsEmailValid { get; set; } = false;

		Regex emailRegEx = new Regex(GameSettings.Default.EmailRegEx);

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

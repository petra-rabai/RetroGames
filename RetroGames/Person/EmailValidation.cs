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
		public string Email { get; set; } = "";
		public bool IsEmailValid { get; set; } = false;

		public string GetPlayerEmail()
		{
			string email = Console.ReadLine();

			Email = email;

			ValidateEmail();

			return Email;
		}

		private bool ValidateEmail()
		{
			Regex emailRegEx = new Regex(GameSettings.Default.EmailRegEx);
			while (!emailRegEx.Match(Email).Success)
			{
				Console.WriteLine("E-mail address not match the requirements! \n"
					+ "Please add a valid e-mail address! \n");
				Email = Console.ReadLine();
			}

			IsEmailValid = true;

			return IsEmailValid;
		}
	}
}

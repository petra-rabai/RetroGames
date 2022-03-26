using RetroGames.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RetroGames.Player
{
	public class PlayerEmail
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

		public bool ValidateEmail()
		{
			Regex emailRegEx = new Regex(Settings.Default.EmailRegEx);
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

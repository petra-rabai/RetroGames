using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class Email : IEmail
	{
		public string PlayerEmail { get; set; } = "";
		EmailValidation EmailValidation { get; set; } = new EmailValidation();

		public string GetPlayerEmail()
		{
			string email = Console.ReadLine();

			EmailValidation.ValidateEmail(email);

			PlayerEmail = email;

			return PlayerEmail;
		}
	}
}

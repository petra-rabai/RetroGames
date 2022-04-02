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

		public string GetPlayerEmail(EmailValidation emailValidation)
		{
			string email = Console.ReadLine();

			emailValidation.ValidateEmail(email);

			PlayerEmail = email;

			return PlayerEmail;
		}
	}
}

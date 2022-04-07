using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class Email : IEmail
	{
		private IEmailValidator emailValidation;

		public Email(IEmailValidator emailValidation)
		{
			this.emailValidation = emailValidation;
		}
		public string PlayerEmail { get; set; } = "";

		public string GetPlayerEmail()
		{
			string email = Console.ReadLine();

			emailValidation.ValidateEmail(email);

			PlayerEmail = email;

			return PlayerEmail;
		}
	}
}

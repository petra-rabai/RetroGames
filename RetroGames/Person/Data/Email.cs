using System;

namespace RetroGames.Person.Data
{
	public class Email : IEmail
	{
		private IEmailValidator _emailValidation;

		public Email(IEmailValidator emailValidation)
		{
			_emailValidation = emailValidation;
		}

		public string PlayerEmail { get; set; } = "";

		public string GetPlayerEmail()
		{
			string email = Console.ReadLine();

			_emailValidation.ValidateEmail(email);

			PlayerEmail = email;

			return PlayerEmail;
		}
	}
}
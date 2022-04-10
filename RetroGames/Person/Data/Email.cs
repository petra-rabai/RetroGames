using System;

namespace RetroGames.Person.Data
{
	public class Email : IEmail
	{
		private IEmailValidator _emailValidator;

		public Email(IEmailValidator emailValidation)
		{
			_emailValidator = emailValidation;
		}

		public string PlayerEmail { get; set; } = "";

		public string GetPlayerEmail()
		{
			string email = Console.ReadLine();

			_emailValidator.ValidateEmail(email);

			PlayerEmail = email;

			return PlayerEmail;
		}
	}
}
using RetroGames.Person.Actions;
using RetroGames.Person.Security;

namespace RetroGames.Person.Data
{
	public class Email : IEmail
	{
		private readonly IEmailValidator _emailValidator;
		private readonly IPlayerInteraction _playerInteraction;

		public Email(IEmailValidator emailValidation, IPlayerInteraction playerInteraction)
		{
			_emailValidator = emailValidation;
			_playerInteraction = playerInteraction;
		}

		public string PlayerEmail { get; set; } = "";

		public string GetPlayerEmail()
		{
			string email = _playerInteraction.GetPlayerEmailFromConsole();

			_emailValidator.ValidateEmail(email);

			PlayerEmail = email;

			return PlayerEmail;
		}
	}
}
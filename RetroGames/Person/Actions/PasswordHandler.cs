using RetroGames.Person.Data;
using RetroGames.Person.Security;

namespace RetroGames.Person.Actions
{
	public class PasswordHandler : IPasswordHandler
	{
		private readonly IPasswordValidator _passwordValidator;
		private readonly IStringCryptographer _stringCryptographer;
		private readonly IPlayerInteraction _playerInteraction;
		public PasswordHandler(IPlayerInteraction playerInteraction, IPasswordValidator passwordValidator, IStringCryptographer stringCryptographer)
		{
			_passwordValidator = passwordValidator;
			_stringCryptographer = stringCryptographer;
			_playerInteraction = playerInteraction;
		}

		public string PlayerPassword { get; set; }
		public bool IsPasswordValid { get; set; }
		public bool IsPasswordEncrypted { get; set; }

		public bool PasswordHandlingSuccess { get; set; }

		public bool CheckPasswordHandling(string playerPassword)
		{

			IsPasswordValid = CheckIsPasswordValid(playerPassword);
			IsPasswordEncrypted = CheckIsPasswordEncrypted(playerPassword);

			if (IsPasswordValid && IsPasswordEncrypted)
			{
				PasswordHandlingSuccess = true;
			}
			else
			{
				PasswordHandlingSuccess = false;
			}

			return PasswordHandlingSuccess;
		}

		public string GetPlayerPassword()
		{
			PlayerPassword = _playerInteraction.ReadPlayerPasswordFromConsole();

			return PlayerPassword;
		}

		private bool CheckIsPasswordValid(string password)
		{
			IsPasswordValid = _passwordValidator.ValidatePassword(password);

			return IsPasswordValid;
		}

		private bool CheckIsPasswordEncrypted(string password)
		{
			_stringCryptographer.EncryptProcess(password);

			PlayerPassword = _stringCryptographer.EncryptResult;

			if (_stringCryptographer.IsEncrypted)
			{
				IsPasswordEncrypted = _stringCryptographer.IsEncrypted;
			}
			else
			{
				IsPasswordEncrypted = false;
			}

			return IsPasswordEncrypted;
		}
	}
}
namespace RetroGames.Person.Actions
{
	public class PasswordHandler : IPasswordHandler
	{
		private readonly IPassword _password;
		private readonly IPasswordValidator _passwordValidator;
		private readonly IStringCryptographer _stringCryptographer;

		public PasswordHandler(IPassword password, IPasswordValidator passwordValidator, IStringCryptographer stringCryptographer)
		{
			_password = password;
			_passwordValidator = passwordValidator;
			_stringCryptographer = stringCryptographer;
		}

		public string PlayerPassword { get; set; }
		public bool IsPasswordValid { get; set; }
		public bool IsPasswordEncrypted { get; set; }

		public bool PasswordHandlingSuccess { get; set; }

		public bool CheckPasswordHandling(string playerPassword)
		{
			CheckIsPasswordValid(playerPassword);
			CheckIsPasswordEncrypted(playerPassword);

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
			PlayerPassword = _password.GetPlayerPassword();

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
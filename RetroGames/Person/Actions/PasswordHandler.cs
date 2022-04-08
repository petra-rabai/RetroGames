namespace RetroGames
{
	public class PasswordHandler : IPasswordHandler
	{
		private IPassword password;
		private IPasswordValidator passwordValidation;
		private IStringCryptographer stringCryptographer;

		public PasswordHandler(IPassword password, IPasswordValidator passwordValidation, IStringCryptographer stringCryptographer)
		{
			this.password = password;
			this.passwordValidation = passwordValidation;
			this.stringCryptographer = stringCryptographer;
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
			PlayerPassword = password.GetPlayerPassword();

			return PlayerPassword;
		}

		private bool CheckIsPasswordValid(string password)
		{
			IsPasswordValid = passwordValidation.ValidatePassword(password);

			return IsPasswordValid;
		}

		private bool CheckIsPasswordEncrypted(string password)
		{
			PlayerPassword = stringCryptographer.Encrypt(password);

			if (stringCryptographer.IsEncrypted)
			{
				IsPasswordEncrypted = stringCryptographer.IsEncrypted;
			}
			else
			{
				IsPasswordEncrypted = false;
			}

			return IsPasswordEncrypted;
		}
	}
}
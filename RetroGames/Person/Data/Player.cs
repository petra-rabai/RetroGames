namespace RetroGames.Person.Data
{
	public class Player : IPlayer
	{
		private IUser _user;
		private IPassword _password;
		private IRegistration _registration;
		private ILogin _login;
		private IPasswordHandler _passwordHandler;

		public Player(IUser user, IPassword password, IRegistration registration, ILogin login, IPasswordHandler passwordHandler)
		{
			_user = user;
			_password = password;
			_registration = registration;
			_login = login;
			_passwordHandler = passwordHandler;
		}

		public string LoginName { get; set; }
		public string PlayerPassword { get; set; }
		public bool IsRegistered { get; set; }
		public bool IsLoggedIn { get; set; }

		public void GetLoginData()
		{
			LoginName = _user.LoginName;
			PlayerPassword = _password.PlayerPassword;

			CheckLoginDataNotEmpty();
		}

		private void CheckLoginDataNotEmpty()
		{
			if (LoginName == "" || PlayerPassword == "")
			{
				GetPlayerLoginName();
				GetPlayerPassword();
			}
		}

		public void GetRegistrationIsSuccess(bool registred)
		{
			CheckRegistrationSuccess(registred);
		}

		public void GetLoginIsSuccess()
		{
			CheckLoginSuccess();
		}

		private string GetPlayerLoginName()
		{
			LoginName = _user.GetPlayerLoginName();

			return LoginName;
		}

		private string GetPlayerPassword()
		{
			while (!_passwordHandler.PasswordHandlingSuccess)
			{
				_passwordHandler.GetPlayerPassword();
				_passwordHandler.CheckPasswordHandling(_passwordHandler.PlayerPassword);
			}

			PlayerPassword = _passwordHandler.PlayerPassword;

			return PlayerPassword;
		}

		private bool CheckRegistrationSuccess(bool registred)
		{
			_registration.IsUserRegistered(registred);

			IsRegistered = _registration.IsRegistered;

			return IsRegistered;
		}

		private bool CheckLoginSuccess()
		{
			IsLoggedIn = _login.IsLoggedIn;

			return IsLoggedIn;
		}
	}
}
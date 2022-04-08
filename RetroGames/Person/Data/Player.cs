using System;
using System.Linq;

namespace RetroGames
{
	public class Player : IPlayer
	{
		private IUser user;
		private IPassword password;
		private IRegistration registration;
		private ILogin login;
		private IPasswordHandler passwordHandler;

		public Player(IUser user, IPassword password, IRegistration registration, ILogin login, IPasswordHandler passwordHandler)
		{
			this.user = user;
			this.password = password;
			this.registration = registration;
			this.login = login;
			this.passwordHandler = passwordHandler;
		}

		public string LoginName { get; set; }	
		public string PlayerPassword { get; set; }
		public bool IsRegistered { get; set; }
		public bool IsLoggedIn { get; set; }

		public void GetLoginData()
		{
			LoginName = user.LoginName;
			PlayerPassword = password.PlayerPassword;

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
			LoginName = user.GetPlayerLoginName();
			
			return LoginName;
		}

		private string GetPlayerPassword()
		{
			while (!passwordHandler.PasswordHandlingSuccess)
			{
				passwordHandler.CheckPasswordHandling(PlayerPassword);
			}

			PlayerPassword = passwordHandler.PlayerPassword;

			return PlayerPassword;
		}

		private bool CheckRegistrationSuccess(bool registred)
		{
			registration.IsUserRegistered(registred);

			IsRegistered = registration.IsRegistered;

			return IsRegistered;
		}

		private bool CheckLoginSuccess()
		{
			IsLoggedIn = login.IsLoggedIn;

			return IsLoggedIn;
		}
		
	}
}

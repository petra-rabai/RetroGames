using RetroGames.Person.Data;
using System.IO;
using System.Xml.Serialization;

namespace RetroGames.Person.Actions
{
	public class Registration : IRegistration
	{
		private IRegistrationUI _registrationUI;
		private IInstallation _installation;
		private IUser _user;
		private IEmail _email;
		private IPasswordHandler _passwordHandler;
		private IPlayerInteraction _playerInteraction;

		public Registration(IRegistrationUI registrationUI,
					  IInstallation installation,
					  IUser user,
					  IEmail email,
					  IPlayerInteraction playerInteraction,
					  IPasswordHandler passwordHandler)
		{
			_registrationUI = registrationUI;
			_installation = installation;
			_user = user;
			_email = email;
			_playerInteraction = playerInteraction;
			_passwordHandler = passwordHandler;
		}

		public bool IsRegistered { get; set; }
		public string Name { get; set; }
		public string LoginName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		private char saveDecesion;
		private bool isRegistrationSuccess;

		public void UserRegistration()
		{
			RegistrationForm();

			IsUserRegistered(isRegistrationSuccess);
		}

		public void SaveDecesionCheck(char decesion)
		{
			if (decesion == 'Y')
			{
				SaveDataSuccess();
			}
			if (decesion == 'N')
			{
				EraseDataSuccess();
			}
		}

		public bool IsUserRegistered(bool registrationSuccess)
		{
			if (registrationSuccess)
			{
				IsRegistered = true;
			}
			else
			{
				IsRegistered = false;
			}

			return IsRegistered;
		}

		private void RegistrationForm()
		{
			GetFormTitle();
			GetFirstName();
			GetLastName();
			AssignName();
			GetLoginName();
			GetPassword();
			GetEmail();
			GetSaveDecesion();
			SaveDecesionCheck(saveDecesion);
		}

		private void GetFormTitle()
		{
			_registrationUI.FormTitle();
		}

		private char GetSaveDecesion()
		{
			_registrationUI.FromSave();

			saveDecesion = _playerInteraction.GetPlayerKeyFromConsole();

			return saveDecesion;
		}

		private void GetEmail()
		{
			_registrationUI.FormEmail();
			Email = _email.GetPlayerEmail();
		}

		private void GetPassword()
		{
			_registrationUI.FormPassword();

			while (!_passwordHandler.PasswordHandlingSuccess)
			{
				_passwordHandler.GetPlayerPassword();
				_passwordHandler.CheckPasswordHandling(_passwordHandler.PlayerPassword);
			}

			Password = _passwordHandler.PlayerPassword;
		}

		private void AssignName()
		{
			Name = _user.FirstName + " " + _user.LastName;
		}

		private void GetLoginName()
		{
			_registrationUI.FormLoginName();
			LoginName = _user.GetPlayerLoginName();
		}

		private void GetLastName()
		{
			_registrationUI.FormLastName();
			_user.GetPlayerLastName();
		}

		private void GetFirstName()
		{
			_registrationUI.FormFirstName();
			_user.GetPlayerFirstName();
		}

		private bool EraseDataSuccess()
		{
			Name.Remove(0, Name.Length);
			LoginName.Remove(0, LoginName.Length);
			Password.Remove(0, Password.Length);
			Email.Remove(0, Email.Length);

			isRegistrationSuccess = false;

			return isRegistrationSuccess;
		}

		private void GetUserSavePath()
		{
			_installation.CheckInstallationSuccess();
		}

		private bool SaveDataSuccess()
		{
			GetUserSavePath();

			RegistrationData registrationData = new()
			{
				Name = this.Name,
				LoginName = this.LoginName,
				Password = this.Password,
				Email = this.Email
			};
			string Path = _installation.UserFilePath;

			XmlSerializer RegistrationWriteToXML = new(typeof(RegistrationData));
			FileStream registrationXML = new(Path,
									 FileMode.Open,
									 FileAccess.Write);

			RegistrationWriteToXML.Serialize(registrationXML, registrationData);
			registrationXML.Close();

			isRegistrationSuccess = true;

			return isRegistrationSuccess;
		}
	}
}
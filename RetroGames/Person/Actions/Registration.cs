using RetroGames.Person.Data;
using System.IO;
using System.Xml.Serialization;
using RetroGames.Game.Actions;
using RetroGames.Game.UI;
using System.IO.Abstractions;


namespace RetroGames.Person.Actions
{
	public class Registration : IRegistration
	{
		private readonly IRegistrationUi _registrationUi;
		private readonly IInstallation _installation;
		private readonly IUser _user;
		private readonly IEmail _email;
		private readonly IPasswordHandler _passwordHandler;
		private readonly IPlayerInteraction _playerInteraction;
		private readonly IFileSystem _fileSystem;
		public Registration(IRegistrationUi registrationUi,
					  IInstallation installation,
					  IUser user,
					  IEmail email,
					  IPlayerInteraction playerInteraction,
					  IPasswordHandler passwordHandler,
					  IFileSystem fileSystem)
		{
			_registrationUi = registrationUi;
			_installation = installation;
			_user = user;
			_email = email;
			_playerInteraction = playerInteraction;
			_passwordHandler = passwordHandler;
			_fileSystem = fileSystem;
		}

		public bool IsRegistered { get; set; }
		public string Name { get; set; }
		public string LoginName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		private char _saveDecesion;
		private bool _isRegistrationSuccess;
		private bool _isPasswordValid;
		private string _savePath;

		public void UserRegistration()
		{
			RegistrationForm();

			IsRegistered = IsUserRegistered(_isRegistrationSuccess);
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
			SaveDecesionCheck(_saveDecesion);
		}

		private void GetFormTitle()
		{
			_registrationUi.FormTitle();
		}

		private char GetSaveDecesion()
		{
			_registrationUi.FromSave();

			_saveDecesion = _playerInteraction.GetPlayerKeyFromConsole();

			return _saveDecesion;
		}

		private void GetEmail()
		{
			_registrationUi.FormEmail();
			Email = _email.GetPlayerEmail();
		}

		private void GetPassword()
		{
			_registrationUi.FormPassword();

			while (!_isPasswordValid)
			{
				Password = _passwordHandler.GetPlayerPassword();
				_isPasswordValid =  _passwordHandler.CheckPasswordHandling(Password);
			}
	
		}

		private void AssignName()
		{
			Name = _user.FirstName + " " + _user.LastName;
		}

		private void GetLoginName()
		{
			_registrationUi.FormLoginName();
			LoginName = _user.GetPlayerLoginName();
		}

		private void GetLastName()
		{
			_registrationUi.FormLastName();
			_user.GetPlayerLastName();
		}

		private void GetFirstName()
		{
			_registrationUi.FormFirstName();
			_user.GetPlayerFirstName();
		}

		private bool EraseDataSuccess()
		{
			Name.Remove(0, Name.Length);
			LoginName.Remove(0, LoginName.Length);
			Password.Remove(0, Password.Length);
			Email.Remove(0, Email.Length);

			_isRegistrationSuccess = false;

			return _isRegistrationSuccess;
		}

		private void GetUserSavePath()
		{
			_installation.CheckInstallationSuccess();
			_savePath = _installation.UserFilePath;
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

			XmlSerializer registrationWriteToXml = new(typeof(RegistrationData));
			Stream registrationXml = _fileSystem.File.OpenWrite(_savePath);

			registrationWriteToXml.Serialize(registrationXml, registrationData);
			registrationXml.Dispose();
			registrationXml.Close();

			_isRegistrationSuccess = true;

			return _isRegistrationSuccess;
		}
	}
}
using System.IO;
using System.Xml.Serialization;

namespace RetroGames
{
	public class Registration : IRegistration
	{
		private IRegistrationUI registrationUI;
		private IInstallation installation;
		private IUser user;
		private IEmail email;
		private IPasswordHandler passwordHandler;
		private IPlayerInteraction playerInteraction;

		public Registration(IRegistrationUI registrationUI,
					  IInstallation installation,
					  IUser user,
					  IEmail email,
					  IPlayerInteraction playerInteraction,
					  IPasswordHandler passwordHandler)
		{
			this.registrationUI = registrationUI;
			this.installation = installation;
			this.user = user;
			this.email = email;
			this.playerInteraction = playerInteraction;
			this.passwordHandler = passwordHandler;
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
			registrationUI.FormTitle();
		}

		private char GetSaveDecesion()
		{
			registrationUI.FromSave();

			saveDecesion = playerInteraction.GetPlayerKeyFromConsole();

			return saveDecesion;
		}

		private void GetEmail()
		{
			registrationUI.FormEmail();
			Email = email.GetPlayerEmail();
		}

		private void GetPassword()
		{
			registrationUI.FormPassword();

			while (!passwordHandler.PasswordHandlingSuccess)
			{
				passwordHandler.GetPlayerPassword();
				passwordHandler.CheckPasswordHandling(passwordHandler.PlayerPassword);
			}

			Password = passwordHandler.PlayerPassword;
		}

		private void AssignName()
		{
			Name = user.FirstName + " " + user.LastName;
		}

		private void GetLoginName()
		{
			registrationUI.FormLoginName();
			LoginName = user.GetPlayerLoginName();
		}

		private void GetLastName()
		{
			registrationUI.FormLastName();
			user.GetPlayerLastName();
		}

		private void GetFirstName()
		{
			registrationUI.FormFirstName();
			user.GetPlayerFirstName();
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
			installation.CheckInstallationSuccess();
		}

		private bool SaveDataSuccess()
		{
			GetUserSavePath();

			RegistrationData registrationData = new RegistrationData()
			{
				Name = this.Name,
				LoginName = this.LoginName,
				Password = this.Password,
				Email = this.Email
			};
			string Path = installation.UserFilePath;

			XmlSerializer RegistrationWriteToXML = new XmlSerializer(typeof(RegistrationData));
			FileStream registrationXML = new FileStream(Path,
									 FileMode.Open,
									 FileAccess.Write);

			RegistrationWriteToXML.Serialize(registrationXML, registrationData);
			registrationXML.Close();

			isRegistrationSuccess = true;

			return isRegistrationSuccess;
		}
	}
}
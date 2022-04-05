using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using RetroGames.Properties;

namespace RetroGames
{
	public class Registration : IRegistration
	{
		public bool IsRegistered { get; set; }
		RegistrationUI RegistrationUI { get; set; } = new RegistrationUI();
		public string Name { get; set; }
		public string LoginName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		private char saveDecesion;
		private bool isRegistrationSuccess;

		public void UserRegistration(GameFile gameFile,
								  User user,
								  Password playerPassword,
								  Email playerEmail,
								  EmailValidation emailValidation,
								 StringCryptographer stringCryptographer,
								  PasswordValidation passwordValidation,
								  Drive drive,
								  GameDirectory gameDirectory,
								  Player player)
		{
			RegistrationForm(gameFile,user,playerPassword,playerEmail,emailValidation, stringCryptographer, passwordValidation,drive,gameDirectory,player);
			
			IsUserRegistered(isRegistrationSuccess);

		}

		public void SaveDecesionCheck(GameFile gameFile, char decesion, Drive drive, GameDirectory gameDirectory)
		{
			if (decesion == 'Y')
			{
				SaveDataSuccess(gameFile,drive,gameDirectory);

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

		private void RegistrationForm(GameFile gameFile,		
								User user,
								Password playerPassword,
								Email playerEmail,
								EmailValidation emailValidation,
								StringCryptographer stringCryptographer,
								PasswordValidation passwordValidation,
								Drive drive, GameDirectory gameDirectory,
								Player player)
		{
			GetFormTitle();
			GetFirstName(user);
			GetLastName(user);
			AssignName(user);
			GetLoginName(user);
			GetPassword(playerPassword, stringCryptographer, passwordValidation);
			GetEmail(playerEmail,emailValidation);
			GetSaveDecesion(player);
			SaveDecesionCheck(gameFile,saveDecesion,drive,gameDirectory);

		}

		private void GetFormTitle()
		{
			RegistrationUI.FormTitle();
		}

		private char GetSaveDecesion(Player player)
		{
			RegistrationUI.FromSave();
			saveDecesion = player.GetPlayerKeyFromConsole();

			return saveDecesion;
		}

		private void GetEmail(Email playerEmail, EmailValidation emailValidation)
		{
			RegistrationUI.FormEmail();
			Email = playerEmail.GetPlayerEmail(emailValidation);
		}

		private void GetPassword(Password playerPassword, StringCryptographer stringCryptographer, PasswordValidation passwordValidation)
		{
			RegistrationUI.FormPassword();
			Password = playerPassword.GetPlayerPassword(stringCryptographer, passwordValidation);
		}

		private void AssignName(User user)
		{
			Name = user.FirstName + " " + user.LastName;
		}

		private void GetLoginName(User user)
		{
			RegistrationUI.FormLoginName();
			LoginName = user.GetPlayerLoginName();
		}

		private void GetLastName(User user)
		{
			RegistrationUI.FormLastName();
			user.GetPlayerLastName();
		}

		private void GetFirstName(User user)
		{
			RegistrationUI.FormFirstName();
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

		private void GetUserSavePath(GameFile gameFile, Drive drive, GameDirectory gameDirectory)
		{
			gameFile.CheckGameFilesCreated(drive,gameDirectory);
		}

		private bool SaveDataSuccess(GameFile gameFile, Drive drive, GameDirectory gameDirectory)
		{
			GetUserSavePath(gameFile, drive,gameDirectory);
			RegistrationData registrationData = new RegistrationData()
			{
				Name = this.Name,
				LoginName = this.LoginName,
				Password = this.Password,
				Email = this.Email
			};
			string Path = gameFile.UserFilePath;

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

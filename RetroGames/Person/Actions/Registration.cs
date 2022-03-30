using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
								  Player player)
		{
			RegistrationForm(gameFile,user,playerPassword,playerEmail,player);
			
			IsUserRegistered(isRegistrationSuccess);

		}

		public void SaveDecesionCheck(GameFile gameFile, char decesion)
		{
			if (decesion == 'Y')
			{
				SaveDataSuccess(gameFile);

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
								Player player)
		{
			GetFormTitle();
			GetFirstName(user);
			GetLastName(user);
			AssignName(user);
			GetLoginName(user);
			GetPassword(playerPassword);
			GetEmail(playerEmail);
			GetSaveDecesion(player);
			SaveDecesionCheck(gameFile,saveDecesion);

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

		private void GetEmail(Email playerEmail)
		{
			RegistrationUI.FormEmail();
			Email = playerEmail.GetPlayerEmail();
		}

		private void GetPassword(Password playerPassword)
		{
			RegistrationUI.FormPassword();
			Password = playerPassword.GetPlayerPassword();
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

		private void GetUserSavePath(GameFile gameFile)
		{
			gameFile.CheckGameFilesCreated();
		}

		private bool SaveDataSuccess(GameFile gameFile)
		{
			GetUserSavePath(gameFile);

			string Path = gameFile.UserFilePath;
			string data = "\n**********************"
				 + "\n"
				 + "Name: "
				 + Name
				 + "\n"
				 + "Login name: "
				 + LoginName
				 + "\n"
				 + "Password: "
				 + Password
				 + "\n"
				 + "E-mail: "
				 + Email
				 + "\n"
				 + "**********************";
			if (File.Exists(gameFile.UserFilePath))
			{
				File.AppendAllText(Path, data);
			}
			
			isRegistrationSuccess = true;

			return isRegistrationSuccess;

		}
	}
}

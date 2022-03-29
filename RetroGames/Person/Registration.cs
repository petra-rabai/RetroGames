﻿using System;
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
		public bool IsRegistered { get; set; } = false;

		private string name;
		private string loginName;
		private string formContent;
		private string password;
		private string email;
		private char saveDecesion;

		public bool RegistrationSuccess(GameFile gameFile,
								  User user,
								  Password playerPassword,
								  Email playerEmail,
								  Player player)
		{
			RegistrationForm(gameFile,user,playerPassword,playerEmail,player);

			return IsRegistered;
		}

		private void RegistrationForm(GameFile gameFile,
								User user,
								Password playerPassword,
								Email playerEmail,
								Player player)
		{
			FormTitle();
			FormFirstName();
			user.GetPlayerFirstName();
			FormLastName();
			user.GetPlayerLastName();
			FormLoginName();
			loginName = user.GetPlayerLoginName();
			name = user.FirstName + " " + user.LastName;
			FormPassword();
			password = playerPassword.GetPlayerPassword();
			FormEmail();
			email = playerEmail.GetPlayerEmail();
			FromSave();
			saveDecesion = player.GetPlayerKeyFromConsole();
			SaveDecesionCheck(gameFile);
			
		}

		private void FormTitle()
		{
			Console.WriteLine("*****************************************************************");
			Console.WriteLine("				New User Registration \n" + "\n ");
			Console.WriteLine("*****************************************************************");
		}

		private void FormFirstName()
		{
			FirstNameUIToConsole();
			Console.WriteLine(formContent + "\n");
		}

		private void FormLastName()
		{
			Console.WriteLine("\n*****************************************************************");
			LastNameUIToConsole();
			Console.WriteLine(formContent + "\n");
		}

		private void FormLoginName()
		{
			Console.WriteLine("\n*****************************************************************");
			LoginNameUIToConsole();
			Console.WriteLine(formContent + "\n");
		}

		private void FormPassword()
		{
			Console.WriteLine("\n*****************************************************************");
			PasswordUIToConsole();
			Console.WriteLine(formContent + "\n");
		}

		private void FormEmail()
		{
			Console.WriteLine("\n*****************************************************************");
			EmailUIToConsole();
			Console.WriteLine(formContent + "\n");
		}

		private void FromSave()
		{
			Console.WriteLine("\n*****************************************************************");
			SaveQuestionUIToConsole();
			Console.WriteLine(formContent + "\n");
		}
		
		private string LoginNameUIToConsole()
		{
			formContent = " * Login Name: * \n";
			return formContent;
		}

		private string FirstNameUIToConsole()
		{
			formContent = " * First Name: * \n";
			return formContent;
		}

		private string LastNameUIToConsole()
		{
			formContent = " * Last Name: * \n";
			return formContent;
		}

		private string PasswordUIToConsole()
		{
			formContent = " * Password: * \n"
				+ "  Password requirement: \n"
				+ " - Length: minimum 6 character \n"
				+ " - 1 Uppercase letter \n"
				+ " - 1 Lowercase letter \n"
				+ " - Contains number \n"
				+ " - 1 Special character (like . or ! etc) \n";

			return formContent;
		}

		private string EmailUIToConsole()
		{
			formContent = " * E-mail: * \n";
			return formContent;
		}

		private string SaveQuestionUIToConsole()
		{
			formContent = "\n Do you want to save your registration? (Y/N) \n"; ;
			return formContent;
		}

		private void SaveDecesionCheck(GameFile gameFile)
		{
			if (saveDecesion == 'Y')
			{
				SaveData(gameFile);

				IsRegistered = true;
			}
			if (saveDecesion == 'N')
			{
				EraseData();

				IsRegistered = false;
			}
		}

		public void EraseData()
		{
			name.Remove(0, name.Length);
			loginName.Remove(0, loginName.Length);
			password.Remove(0, password.Length);
			email.Remove(0, email.Length);
		}

		public void SaveData(GameFile gameFile)
		{
			string Path = GameSettings.Default.UserDirectory + GameSettings.Default.UserFile;
			string data = "\n**********************"
				 + "\n"
				 + "Name: "
				 + name
				 + "\n"
				 + "Login name: "
				 + loginName
				 + "\n"
				 + "Password: "
				 + password
				 + "\n"
				 + "E-mail: "
				 + email
				 + "\n"
				 + "**********************";
			if (File.Exists(gameFile.UserFilePath))
			{
				File.AppendAllText(Path, data);
			}
			 
		}
	}
}

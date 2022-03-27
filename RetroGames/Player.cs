using RetroGames.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RetroGames
{
	public class Player : IUser, IPasswordValidation, IPasswordEncrypter, IEmailValidation, IRegistration, ILogin
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string LoginName { get ; set ; }
		public string Email { get; set; }
		public bool IsEmailValid { get; set; }
		User User { get; set; } = new User();
		EmailValidation EmailValidation { get; set; } = new EmailValidation();
		PasswordValidation PasswordValidation { get; set; } = new PasswordValidation();
		PasswordEncrypter PasswordEncrypter { get; set; } = new PasswordEncrypter();
		public bool IsPasswordValid { get; set; }
		public string Password { get; set; }
		public bool IsPasswordEncrypted { get; set; }
		public bool IsRegistered { get; set; }
		public bool IsLoggedIn { get; set; }

		public string GetPlayerFirstName()
		{
			FirstName = User.GetPlayerFirstName();
			
			return FirstName;
		}

		public string GetPlayerLastName()
		{
			LastName = User.GetPlayerLastName();

			return LastName;
		}

		public string GetPlayerLoginName()
		{
			LoginName = User.GetPlayerLoginName();

			return LoginName;
		}

		public string GetPlayerEmail()
		{
			Email = EmailValidation.GetPlayerEmail();

			IsEmailValid = EmailValidation.IsEmailValid;
			
			return Email;
		}

		public string GetPlayerPassword()
		{
			Password = PasswordValidation.GetPlayerPassword();
			
			IsPasswordValid = PasswordValidation.IsPasswordValid;

			return Password;
		}

		public string EncryptPassword(string plaintext)
		{
			plaintext = Password;
			
			PasswordEncrypter.EncryptPassword(plaintext);

			IsPasswordEncrypted = PasswordEncrypter.IsPasswordEncrypted;
			
			return Password;
		}
	}
}

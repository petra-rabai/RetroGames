﻿using RetroGames.Properties;
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
	public class Playerx
	{
		readonly SecureString securePassword = new SecureString();
		public string FirstName { get; set; } = "";
		public string LastName { get; set; } = "";
		public string Email { get; set; } = "";
		public string Password { get; set; } = "";
		public string LoginName { get; set; } = "";
		public bool IsLoggedIn { get; set; } = false;
		public bool IsRegistered { get; set; } = false;
		public bool IsPasswordValid { get; set; } = false;
		public bool IsPasswordEncrypted { get; set; } = false;
		public bool IsEmailValid { get; set; } = false;
		public char PressedKey { get; set; } = ' ';
		
		public string GetPlayerFirstName()
		{
			string firstName = Console.ReadLine();
			
			FirstName = firstName;
			
			return FirstName;
		}
		public string GetPlayerLastName()
		{
			string lastName = Console.ReadLine();

			LastName = lastName;

			return LastName;
		}
		public string GetPlayerLoginName()
		{
			string loginName = Console.ReadLine();

			LoginName = loginName;

			return LoginName;
		}
		public string GetPlayerPassword()
		{
			SecureString password = ConvertPasswordToSecure();
			string passWordConvert = new NetworkCredential(string.Empty, password).Password;
			
			Password = passWordConvert;

			ValidatePassword();

			Password = EncryptString(Password);

			return Password;
		}

		public bool ValidatePassword()
		{
			Regex PasswordRegEx = new Regex(Settings.Default.PasswordRegEx);
			while (!PasswordRegEx.Match(Password).Success)
			{
				string passwordError = GetPasswordError();

				Console.WriteLine("Password not match the requirements!\n"
					+ passwordError
					+ "\n"
					+ "Please add a valid password! \n");
				ConvertPasswordToSecure();
			}

			IsPasswordValid = true;

			return IsPasswordValid;
		}

		public string GetPasswordError()
		{
			Regex hasNumber = new Regex(@"[0-9]+");
			Regex hasUpperChar = new Regex(@"[A-Z]+");
			Regex hasMiniMaxChars = new Regex(@".{8,15}");
			Regex hasLowerChar = new Regex(@"[a-z]+");
			Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
			string passwordError;

			if (!hasLowerChar.IsMatch(Password))
			{
				passwordError = "Password should contain at least one lower case letter.";
			}
			else if (!hasUpperChar.IsMatch(Password))
			{
				passwordError = "Password should contain at least one upper case letter.";
			}
			else if (!hasMiniMaxChars.IsMatch(Password))
			{
				passwordError = "Password should not be lesser than 8 or greater than 15 characters.";
			}
			else if (!hasNumber.IsMatch(Password))
			{
				passwordError = "Password should contain at least one numeric value.";
			}

			else if (!hasSymbols.IsMatch(Password))
			{
				passwordError = "Password should contain at least one special case character.";
			}
			else
			{
				passwordError = "";
			}

			return passwordError;
		}

		public string EncryptString(string plaintext)
		{
			byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(plaintext);
			string encryptedtext = Convert.ToBase64String(b);

			IsPasswordEncrypted = true;

			return encryptedtext;
		}

		public SecureString ConvertPasswordToSecure()
		{
			while (true)
			{
				ConsoleKeyInfo hitKeyInfo = Console.ReadKey(true);

				if (hitKeyInfo.Key == ConsoleKey.Enter)
				{
					break;
				}
				else if (hitKeyInfo.Key == ConsoleKey.Backspace)
				{
					if (securePassword.Length > 0)
					{
						securePassword.RemoveAt(securePassword.Length - 1);
						Console.Write("\b \b");
					}
				}
				else if (hitKeyInfo.KeyChar != '\u0000')
				{
					securePassword.AppendChar(hitKeyInfo.KeyChar);
					Console.Write("*");
				}
			}

			return securePassword;
		}

		public string GetPlayerEmail()
		{
			string email = Console.ReadLine();

			Email = email;

			ValidateEmail();

			return Email;
		}

		

		public bool ValidateEmail()
		{
			Regex emailRegEx = new Regex(Settings.Default.EmailRegEx);
			while (!emailRegEx.Match(Email).Success)
			{
				Console.WriteLine("E-mail address not match the requirements! \n"
					+ "Please add a valid e-mail address! \n");
				Email = Console.ReadLine();
			}

			IsEmailValid = true;

			return IsEmailValid;
		}
		public bool RegistrationSuccess()
		{
			return IsRegistered;
		}
		public bool LoginSuccess()
		{
			return IsLoggedIn;
		}

	}
}

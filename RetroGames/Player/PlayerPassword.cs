using RetroGames.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RetroGames.Player
{
	public class PlayerPassword
	{
		public string Password { get; set; } = "";
		readonly SecureString securePassword = new SecureString();
		public bool IsPasswordValid { get; set; } = false;
		public bool IsPasswordEncrypted { get; set; } = false;

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
	}
}

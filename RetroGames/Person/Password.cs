using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class Password : IPassword, IPasswordValidation
	{
		public string PlayerPassword { get; set; } = "";
		public bool IsPasswordValid { get; set; }
		public bool IsPasswordEncrypted { get; set; }
		PasswordValidation PasswordValidation { get; set; } = new PasswordValidation();
		PasswordEncrypter PasswordEncrypter { get; set; } = new PasswordEncrypter();
		public string PasswordError { get; set; }

		readonly SecureString securePassword = new SecureString();

		public string GetPlayerPassword()
		{
			SecureString password = ConvertPasswordToSecure();
			string passWordConvert = new NetworkCredential(string.Empty, password).Password;

			PlayerPassword = passWordConvert;

			CheckIsPasswordValid(PlayerPassword);
			CheckIsPasswordEncrypted(PlayerPassword);

			return PlayerPassword;
		}

		public void CheckIsPasswordEncrypted(string password)
		{
			GetIsPasswordEncrypted(password);
		}
		
		private bool GetIsPasswordEncrypted(string password)
		{
			PasswordEncrypter.EncryptPassword(password);

			IsPasswordEncrypted = PasswordEncrypter.IsPasswordEncrypted;

			return IsPasswordEncrypted;
		}

		public void CheckIsPasswordValid(string password)
		{
			GetIsPasswordValid(password);
		}

		private bool GetIsPasswordValid(string password)
		{
			PasswordValidation.ValidatePassword(password);

			IsPasswordValid = PasswordValidation.IsPasswordValid;

			return IsPasswordValid;
		}

		private SecureString ConvertPasswordToSecure()
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

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
		public string PasswordError { get; set; }

		readonly SecureString securePassword = new SecureString();

		public string GetPlayerPassword(StringCryptographer stringCryptographer, PasswordValidation passwordValidation)
		{
			SecureString password = ConvertPasswordToSecure();
			string passWordConvert = new NetworkCredential(string.Empty, password).Password;

			PlayerPassword = passWordConvert;

			CheckIsPasswordValid(PlayerPassword,passwordValidation);
			CheckIsPasswordEncrypted(PlayerPassword, stringCryptographer);

			return PlayerPassword;
		}

		public void CheckIsPasswordEncrypted(string password, StringCryptographer stringCryptographer)
		{
			GetIsPasswordEncrypted(password, stringCryptographer);
		}
		
		private bool GetIsPasswordEncrypted(string password, StringCryptographer stringCryptographer)
		{

			stringCryptographer.Encrypt(password);

			IsPasswordEncrypted = stringCryptographer.IsEncrypted;

			return IsPasswordEncrypted;
		}

		public void CheckIsPasswordValid(string password, PasswordValidation passwordValidation)
		{
			GetIsPasswordValid(password,passwordValidation);
		}

		private bool GetIsPasswordValid(string password, PasswordValidation passwordValidation)
		{
			passwordValidation.ValidatePassword(password);

			IsPasswordValid = passwordValidation.IsPasswordValid;

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

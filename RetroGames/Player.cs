using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class Player
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

			Password = password.ToString();

			return Password;
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

			return Email;
		}

		public bool ValidatePassword()
		{
			string passWordConvert = new NetworkCredential(string.Empty, securePassword).Password;

			Password = passWordConvert;

			return IsPasswordValid;
		}
		public bool ValidateEmail()
		{
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

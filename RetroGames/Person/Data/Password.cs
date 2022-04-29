using System;
using System.Net;
using System.Security;

namespace RetroGames.Person.Data
{
	public class Password : IPassword
	{
		public string PlayerPassword { get; set; } = "";

		private readonly SecureString _securePassword = new SecureString();

		public string SetPlayerPassword()
		{
			SecureString password = ConvertPasswordToSecure();
			string passWordConvert = new NetworkCredential(string.Empty, password).Password;

			PlayerPassword = passWordConvert;

			return PlayerPassword;
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
					if (_securePassword.Length > 0)
					{
						_securePassword.RemoveAt(_securePassword.Length - 1);
						Console.Write("\b \b");
					}
				}
				else if (hitKeyInfo.KeyChar != '\u0000')
				{
					_securePassword.AppendChar(hitKeyInfo.KeyChar);
					Console.Write("*");
				}
			}

			return _securePassword;
		}
	}
}
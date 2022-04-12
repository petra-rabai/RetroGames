using System;
using System.Net;
using System.Security;

namespace RetroGames.Person.Data
{
	public class Password : IPassword
	{
		public string PlayerPassword { get; set; } = "";

		private readonly SecureString securePassword = new SecureString();

		public string GetPlayerPassword()
		{
			SecureString password = ConvertPasswordToSecure();
			string passWordConvert = new NetworkCredential(string.Empty, password).Password;

			PlayerPassword = passWordConvert;

			return PlayerPassword;
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
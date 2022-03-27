using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class PasswordEncrypter : IPasswordEncrypter
	{
		public bool IsPasswordEncrypted { get; set; } = false;

		public string EncryptPassword(string plaintext)
		{
			byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(plaintext);
			string encryptedtext = Convert.ToBase64String(b);

			IsPasswordEncrypted = true;

			return encryptedtext;
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RetroGames.Properties;

namespace RetroGames
{
	public class PasswordDeCrypter : IPasswordDeCrypter
	{
		public bool IsPasswordDecrypted { get; set; } = false;

		public string DecryptPassword(string textToDecrypt)
		{
			string publickey = GameSettings.Default.CryptographyPublicKey;
			string secretkey = GameSettings.Default.CryptographySecretKey;
			string decryptedtext = "";
			byte[] privatekeyByte = { };
			privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
			byte[] publickeybyte = { };
			publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
			MemoryStream memoryStream;
			CryptoStream cryptoStream;
			byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
			inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
			DESCryptoServiceProvider cryptoService = new DESCryptoServiceProvider();
			memoryStream = new MemoryStream();
			cryptoStream = new CryptoStream(memoryStream, cryptoService.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
			cryptoStream.Write(inputbyteArray, 0, inputbyteArray.Length);
			cryptoStream.FlushFinalBlock();
			Encoding encoding = Encoding.UTF8;
			decryptedtext = encoding.GetString(memoryStream.ToArray());

			IsPasswordDecrypted = true;

			return decryptedtext;
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using RetroGames.Properties;

namespace RetroGames
{
	public class PasswordEncrypter : IPasswordEncrypter
	{
		public bool IsPasswordEncrypted { get; set; } = false;

		public string EncryptPassword(string plaintext)
		{
			string publickey = GameSettings.Default.CryptographyPublicKey;
			string secretkey = GameSettings.Default.CryptographySecretKey;
			string encryptedtext;
			
			byte[] secretkeyByte = Encoding.UTF8.GetBytes(secretkey);
			byte[] publickeybyte = Encoding.UTF8.GetBytes(publickey);
			byte[] inputbyteArray = Encoding.UTF8.GetBytes(plaintext);
			
			MemoryStream memoryStream = new MemoryStream();
			DESCryptoServiceProvider cryptoService = new DESCryptoServiceProvider();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoService.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
			
			cryptoStream.Write(inputbyteArray, 0, inputbyteArray.Length);
			cryptoStream.FlushFinalBlock();
			encryptedtext = Convert.ToBase64String(memoryStream.ToArray());
			
			IsPasswordEncrypted = true;

			return encryptedtext;
		}
	}
}

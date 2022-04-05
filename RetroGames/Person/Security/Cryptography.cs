using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using RetroGames.Properties;

namespace RetroGames
{
	public class StringCryptographer
	{
		public bool IsEncrypted { get; set; }
		
		public bool IsDecrypted { get; set; }

		public string Encrypt(string plaintext)
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

				IsEncrypted = true;

				return encryptedtext;
			

		}

		

		public string Decrypt(string encryptedText)
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
			byte[] inputbyteArray = new byte[encryptedText.Replace(" ", "+").Length];
			inputbyteArray = Convert.FromBase64String(encryptedText.Replace(" ", "+"));
			DESCryptoServiceProvider cryptoService = new DESCryptoServiceProvider();
			memoryStream = new MemoryStream();
			cryptoStream = new CryptoStream(memoryStream, cryptoService.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
			cryptoStream.Write(inputbyteArray, 0, inputbyteArray.Length);
			cryptoStream.FlushFinalBlock();
			Encoding encoding = Encoding.UTF8;
			decryptedtext = encoding.GetString(memoryStream.ToArray());

			IsDecrypted = true;

			return decryptedtext;


		}

	}
}
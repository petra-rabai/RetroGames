using RetroGames.Properties;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RetroGames.Person.Security
{
	public class StringCryptographer : IStringCryptographer
	{
		public bool IsEncrypted { get; set; }

		public bool IsDecrypted { get; set; }
		public string EncryptResult { get; set; } = "";
		public string DecryptResult { get; set; } = "";

		public bool EncryptProcess(string plainText)
		{
			EncryptResult = Encrypt(plainText);
			CheckIsEncrypted(EncryptResult);

			return IsEncrypted;
		}

		public bool DecryptProcess(string encryptedText)
		{
			DecryptResult = Decrypt(encryptedText);
			CheckIsDecrypted(DecryptResult);

			return IsDecrypted;
		}

		private string Encrypt(string plaintext)
		{
			string publickey = GameSettings.Default.CryptographyPublicKey;
			string secretkey = GameSettings.Default.CryptographySecretKey;

			byte[] secretkeyByte = Encoding.UTF8.GetBytes(secretkey);
			byte[] publickeybyte = Encoding.UTF8.GetBytes(publickey);
			byte[] inputbyteArray = Encoding.UTF8.GetBytes(plaintext);

			MemoryStream memoryStream = new MemoryStream();
			DES cryptoService = DES.Create();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoService.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);

			cryptoStream.Write(inputbyteArray, 0, inputbyteArray.Length);
			cryptoStream.FlushFinalBlock();
			EncryptResult = Convert.ToBase64String(memoryStream.ToArray());

			return EncryptResult;
		}

		public bool CheckIsEncrypted(string encryptedText)
		{
			if (encryptedText != "")
			{
				IsEncrypted = true;
			}
			else
			{
				IsEncrypted = false;
			}

			return IsEncrypted;
		}

		public bool CheckIsDecrypted(string decryptedText)
		{
			if (decryptedText != "")
			{
				IsDecrypted = true;
			}
			else
			{
				IsDecrypted = false;
			}

			return IsDecrypted;
		}

		private string Decrypt(string encryptedText)
		{
			string publickey = GameSettings.Default.CryptographyPublicKey;
			string secretkey = GameSettings.Default.CryptographySecretKey;

			byte[] privatekeyByte;
			privatekeyByte = Encoding.UTF8.GetBytes(secretkey);
			byte[] publickeybyte;
			publickeybyte = Encoding.UTF8.GetBytes(publickey);
			MemoryStream memoryStream;
			CryptoStream cryptoStream;
			byte[] inputbyteArray;
			inputbyteArray = Convert.FromBase64String(encryptedText.Replace(" ", "+"));
			DES cryptoService = DES.Create();
			memoryStream = new MemoryStream();
			cryptoStream = new CryptoStream(memoryStream, cryptoService.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
			cryptoStream.Write(inputbyteArray, 0, inputbyteArray.Length);
			cryptoStream.FlushFinalBlock();
			Encoding encoding = Encoding.UTF8;
			DecryptResult = encoding.GetString(memoryStream.ToArray());

			return DecryptResult;
		}
	}
}
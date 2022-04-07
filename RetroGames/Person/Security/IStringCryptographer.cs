namespace RetroGames
{
	public interface IStringCryptographer
	{
		bool IsDecrypted { get; set; }
		bool IsEncrypted { get; set; }

		string Decrypt(string encryptedText);
		string Encrypt(string plaintext);
	}
}
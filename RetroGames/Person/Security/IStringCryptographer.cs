namespace RetroGames
{
	public interface IStringCryptographer
	{
		bool IsDecrypted { get; set; }
		bool IsEncrypted { get; set; }
		string DecryptResult { get; set; }
		string EncryptResult { get; set; }


		bool EncryptProcess(string plainText);

		bool DecryptProcess(string encryptedText);

		bool CheckIsDecrypted(string encryptedText);

		bool CheckIsEncrypted(string encryptedText);
	}
}
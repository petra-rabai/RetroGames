namespace RetroGames
{
	public interface IPasswordEncrypter
	{
		bool IsPasswordEncrypted { get; set; }

		string EncryptPassword(string plaintext);
	}
}
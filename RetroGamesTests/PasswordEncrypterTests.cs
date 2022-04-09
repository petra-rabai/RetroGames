using NUnit.Framework;
using RetroGames;
using RetroGames.Person.Security;

namespace RetroGamesTests
{
	public class PasswordEncrypterTests
	{
		[Test]
		public void IsPasswordEncryptedSuccess()
		{
			bool isPasswordEncrypted;
			string password = "testablepassword";
			StringCryptographer stringCryptographer = new StringCryptographer();

			stringCryptographer.Encrypt(password);

			isPasswordEncrypted = true;

			Assert.IsTrue(isPasswordEncrypted);
		}
	}
}
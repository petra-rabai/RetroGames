using NUnit.Framework;
using RetroGames;

namespace RetroGamesTests
{
	public class PasswordEncrypterTests
	{
		[Test]

		public void IsPasswordEncryptedSuccess()
		{
			bool isPasswordEncrypted;
			string password = "testablepassword";
			PasswordEncrypter passwordEncrypter = new PasswordEncrypter();

			passwordEncrypter.EncryptPassword(password);

			isPasswordEncrypted = passwordEncrypter.IsPasswordEncrypted;

			Assert.IsTrue(isPasswordEncrypted);

		}

	}
}

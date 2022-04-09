using NUnit.Framework;
using RetroGames;
using RetroGames.Person.Actions;
using RetroGames.Person.Data;
using RetroGames.Person.Security;

namespace RetroGamesTests
{
	public class PasswordTests
	{
		[TestCase("Rp!.12846ee")]
		[Test]
		public void CheckIsPasswordValid(string testPassword)
		{
			bool isPasswordValid;

			IPassword password = new Password();
			IPasswordValidator passwordValidator = new PasswordValidator();
			IStringCryptographer stringCryptographer = new StringCryptographer();

			PasswordHandler passwordHandler = new(password, passwordValidator, stringCryptographer);

			passwordHandler.CheckPasswordHandling(testPassword);

			isPasswordValid = passwordHandler.IsPasswordValid;

			Assert.IsTrue(isPasswordValid);
		}

		[TestCase("Rp!.12846ee")]
		[Test]
		public void CheckIsPasswordEncrypted(string testPassword)
		{
			bool isPasswordEncrypted;

			IPassword password = new Password();
			IPasswordValidator passwordValidator = new PasswordValidator();
			IStringCryptographer stringCryptographer = new StringCryptographer();

			PasswordHandler passwordHandler = new(password, passwordValidator, stringCryptographer);

			passwordHandler.CheckPasswordHandling(testPassword);

			isPasswordEncrypted = passwordHandler.IsPasswordEncrypted;

			Assert.IsTrue(isPasswordEncrypted);
		}
	}
}
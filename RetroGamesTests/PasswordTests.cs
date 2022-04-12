using NUnit.Framework;
using RetroGames;
using RetroGames.Person.Actions;
using RetroGames.Person.Data;
using RetroGames.Person.Security;
using FluentAssertions;
using Moq;
using System.Security;
using System.Net;

namespace RetroGamesTests
{
	public class PasswordTests
	{
		
		[Test]
		public void GetPlayerPasswordSuccess()
		{
			SecureString testSecureString = new NetworkCredential("", "testPassword").SecurePassword;
			string testPassword = "";
			Mock<IPassword> mockPassword = new();
			mockPassword
				.Setup(mockSetup => mockSetup.ConvertPasswordToSecure())
				.Returns(() => { return testSecureString; });

			IPassword password = mockPassword.Object;
			
			password.GetPlayerPassword();

			testPassword = password.PlayerPassword;

			testPassword.Should().NotBeEmpty();
		}
		
		//[TestCase("Rp!.12846ee")]
		//[Test]
		//public void CheckIsPasswordValid(string testPassword)
		//{
		//	bool isPasswordValid;

		//	IPassword password = new Password();
		//	IPasswordValidator passwordValidator = new PasswordValidator();
		//	IStringCryptographer stringCryptographer = new StringCryptographer();

		//	PasswordHandler passwordHandler = new(password, passwordValidator, stringCryptographer);

		//	passwordHandler.CheckPasswordHandling(testPassword);

		//	isPasswordValid = passwordHandler.IsPasswordValid;

		//	Assert.IsTrue(isPasswordValid);
		//}

		//[TestCase("Rp!.12846ee")]
		//[Test]
		//public void CheckIsPasswordEncrypted(string testPassword)
		//{
		//	bool isPasswordEncrypted;

		//	IPassword password = new Password();
		//	IPasswordValidator passwordValidator = new PasswordValidator();
		//	IStringCryptographer stringCryptographer = new StringCryptographer();

		//	PasswordHandler passwordHandler = new(password, passwordValidator, stringCryptographer);

		//	passwordHandler.CheckPasswordHandling(testPassword);

		//	isPasswordEncrypted = passwordHandler.IsPasswordEncrypted;

		//	Assert.IsTrue(isPasswordEncrypted);
		//}
	}
}
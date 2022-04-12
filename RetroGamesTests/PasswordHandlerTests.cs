using FluentAssertions;
using Moq;
using NUnit.Framework;
using RetroGames;
using RetroGames.Person.Actions;
using RetroGames.Person.Security;

namespace RetroGamesTests
{
	public class PasswordHandlerTests
	{
		[Test]
		public void CheckGetPlayerKeySuccess()
		{
			string testpassword = "Rp!x123592";
			
			Mock<IPassword> mockPassword = new(MockBehavior.Strict);
			mockPassword
				.Setup(mockSetup => mockSetup.GetPlayerPassword())
				.Returns(testpassword);

			IPasswordValidator passwordValidator = new PasswordValidator();
			IStringCryptographer stringCryptographer = new StringCryptographer();

			PasswordHandler passwordHandler = new(mockPassword.Object, passwordValidator,stringCryptographer);

			passwordHandler.GetPlayerPassword();

			testpassword = passwordHandler.PlayerPassword;

			mockPassword.Verify(mockVerify => mockVerify.GetPlayerPassword(), Times.Once());

			testpassword.Should().Be(passwordHandler.PlayerPassword);
		}

		[Test]
		public void CheckIsPasswordHandlingFailed()
		{
			string testPassword = "Rp!x123592";
			bool isPasswordHandlingFailed;

			Mock<IPasswordValidator> mockPasswordValidator = new();
			mockPasswordValidator
				.Setup(mockSetup => mockSetup.IsPasswordValid)
				.Returns(false);
			
			Mock<IStringCryptographer> mockStringCryptographer = new();
			mockStringCryptographer
				.Setup(mockSetup => mockSetup.IsEncrypted)
				.Returns(false);

			Mock<IPassword> mockPassword = new(MockBehavior.Strict);
			mockPassword
				.Setup(mockSetup => mockSetup.GetPlayerPassword())
				.Returns(testPassword);

			PasswordHandler passwordHandler = new(mockPassword.Object, mockPasswordValidator.Object, mockStringCryptographer.Object);
			
			passwordHandler.CheckPasswordHandling(testPassword);

			isPasswordHandlingFailed = passwordHandler.PasswordHandlingSuccess;

			isPasswordHandlingFailed.Should().BeFalse();

		}
	}
}

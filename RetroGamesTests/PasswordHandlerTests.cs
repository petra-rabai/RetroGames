using FluentAssertions;
using Moq;
using NUnit.Framework;
using RetroGames;
using RetroGames.Person.Actions;
using RetroGames.Person.Data;
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

			PasswordHandler passwordHandler = new(mockPassword.Object, passwordValidator, stringCryptographer);

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
			bool mockValidation = false;

			Mock<IPasswordValidator> mockPasswordValidator = new(MockBehavior.Strict);
			mockPasswordValidator
				.Setup(mockSetup => mockSetup.ValidatePassword(testPassword))
				.Returns(() => { return mockValidation; });

			Mock<IStringCryptographer> mockStringCryptographer = new(MockBehavior.Strict);
			mockStringCryptographer
				.Setup(mockSetup => mockSetup.EncryptProcess(testPassword))
				.Returns(() => { return mockValidation; });
			mockStringCryptographer
				.Setup(mockSetup => mockSetup.CheckIsEncrypted(testPassword))
				.Returns(() => { return mockValidation; });
			mockStringCryptographer
				.Setup(mockSetup => mockSetup.EncryptResult)
				.Returns(() => { return testPassword; });
			mockStringCryptographer
				.Setup(mockSetup => mockSetup.IsEncrypted)
				.Returns(() => { return mockValidation; });

			Mock<IPassword> mockPassword = new(MockBehavior.Strict);
			mockPassword
				.Setup(mockSetup => mockSetup.GetPlayerPassword())
				.Returns(() => { return testPassword; });

			PasswordHandler passwordHandler = new(mockPassword.Object, mockPasswordValidator.Object, mockStringCryptographer.Object);

			passwordHandler.CheckPasswordHandling(testPassword);

			isPasswordHandlingFailed = passwordHandler.PasswordHandlingSuccess;

			isPasswordHandlingFailed.Should().BeFalse();
		}

		[Test]
		public void CheckIsPasswordHandlingTrue()
		{
			string testPassword = "Rp!x123592";
			bool isPasswordHandlingTrue;
			bool mockValidation = true;

			Mock<IPasswordValidator> mockPasswordValidator = new(MockBehavior.Strict);
			mockPasswordValidator
				.Setup(mockSetup => mockSetup.ValidatePassword(testPassword))
				.Returns(() => { return mockValidation; });

			Mock<IStringCryptographer> mockStringCryptographer = new(MockBehavior.Strict);
			mockStringCryptographer
				.Setup(mockSetup => mockSetup.EncryptProcess(testPassword))
				.Returns(() => { return mockValidation; });
			mockStringCryptographer
				.Setup(mockSetup => mockSetup.CheckIsEncrypted(testPassword))
				.Returns(() => { return mockValidation; });
			mockStringCryptographer
				.Setup(mockSetup => mockSetup.EncryptResult)
				.Returns(() => { return testPassword; });
			mockStringCryptographer
				.Setup(mockSetup => mockSetup.IsEncrypted)
				.Returns(() => { return mockValidation; });

			Mock<IPassword> mockPassword = new(MockBehavior.Strict);
			mockPassword
				.Setup(mockSetup => mockSetup.GetPlayerPassword())
				.Returns(() => { return testPassword; });

			PasswordHandler passwordHandler = new(mockPassword.Object, mockPasswordValidator.Object, mockStringCryptographer.Object);

			passwordHandler.CheckPasswordHandling(testPassword);

			isPasswordHandlingTrue = passwordHandler.PasswordHandlingSuccess;

			isPasswordHandlingTrue.Should().BeTrue();
		}
	}
}
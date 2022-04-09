using NUnit.Framework;
using RetroGames;
using RetroGames.Person.Security;

namespace RetroGamesTests
{
	public class EmailValidationTests
	{
		[TestCase("test@test.com")]
		[Test]
		public void IsEmailValidationSuccess(string testemail)
		{
			bool isEmailValid;
			EmailValidator emailValidation = new EmailValidator();

			emailValidation.ValidateEmail(testemail);

			isEmailValid = emailValidation.IsEmailValid;

			Assert.IsTrue(isEmailValid);
		}

		[TestCase("testtest.com")]
		[Test]
		public void IsEmailValidationFailed(string testemail)
		{
			bool isEmailValid;
			EmailValidator emailValidation = new EmailValidator();

			emailValidation.ValidateEmail(testemail);

			isEmailValid = emailValidation.IsEmailValid;

			Assert.IsFalse(isEmailValid);
		}
	}
}
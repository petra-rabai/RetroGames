using NUnit.Framework;
using RetroGames;

namespace RetroGamesTests
{
	public class EmailValidationTests
	{
		[TestCase("test@test.com")]
		[Test]

		public void IsEmailValidationSuccess(string testemail)
		{
			bool isEmailValid;
			EmailValidation emailValidation = new EmailValidation();

			emailValidation.ValidateEmail(testemail);

			isEmailValid = emailValidation.IsEmailValid;

			Assert.IsTrue(isEmailValid);
		}

		[TestCase("testtest.com")]
		[Test]

		public void IsEmailValidationFailed(string testemail)
		{
			bool isEmailValid;
			EmailValidation emailValidation = new EmailValidation();

			emailValidation.ValidateEmail(testemail);

			isEmailValid = emailValidation.IsEmailValid;

			Assert.IsFalse(isEmailValid);
		}

	}
}

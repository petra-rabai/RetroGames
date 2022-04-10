using NUnit.Framework;
using FluentAssertions;
using RetroGames.Person.Security;

namespace RetroGamesTests
{
	public class EmailValidatorTests
	{
		[TestCase("test@test.com")]
		[TestCase("test@gmail.com")]
		[TestCase("x-test@test.hu")]
		[TestCase("xtest@x-test.hu")]
		[TestCase("xtest12@xtest.hu")]
		[TestCase("xtest@x-11test.hu")]
		[Test]
		public void IsEmailValidationSuccess(string testemail)
		{
			bool isEmailValid;
			EmailValidator emailValidator = new();

			emailValidator.ValidateEmail(testemail);

			isEmailValid = emailValidator.IsEmailValid;

			isEmailValid.Should().BeTrue();
		}

		[TestCase("testtest.com")]
		[TestCase("")]
		[TestCase("test@.test")]
		[TestCase("test@")]
		[TestCase("@test.com")]
		[TestCase("test@.test")]
		[TestCase("test@@test.com")]
		[Test]
		public void IsEmailValidationFailed(string testemail)
		{
			bool isEmailValid;
			EmailValidator emailValidator = new EmailValidator();

			emailValidator.ValidateEmail(testemail);

			isEmailValid = emailValidator.IsEmailValid;

			isEmailValid.Should().BeFalse();
		}
	}
}
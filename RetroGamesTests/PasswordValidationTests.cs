﻿using NUnit.Framework;
using RetroGames;

namespace RetroGamesTests
{
	public class PasswordValidationTests
	{
		[TestCase("Rp!.1984xxR")]
		[Test]

		public void IsPasswordValidSuccess(string testPassword)
		{
			bool passwordValid;

			PasswordValidation passwordValidation = new PasswordValidation();
			
			passwordValidation.ValidatePassword(testPassword);
			
			passwordValid = passwordValidation.IsPasswordValid;
			
			Assert.IsTrue(passwordValid);
		}

		[TestCase("Rpx3")]
		[Test]
		public void IsPasswordValidFailed(string testPassword)
		{
			bool passwordValid;
			PasswordValidation passwordValidation = new PasswordValidation();

			passwordValidation.ValidatePassword(testPassword);
			passwordValid = passwordValidation.IsPasswordValid;

			Assert.IsFalse(passwordValid);
		}

		[TestCase("PR.!rrrrrf")]
		[Test]
		public void CheckPassWordHasNumberFailed(string testPassword)
		{
			string errorMessage;
			string testErrorMessage = "Password should contain at least one numeric value.";
			PasswordValidation passwordValidation = new PasswordValidation();

			passwordValidation.ValidatePassword(testPassword);

			errorMessage = passwordValidation.PasswordError;

			Assert.IsNotNull(errorMessage);
			Assert.AreEqual(errorMessage, testErrorMessage);
		}

		[TestCase("rr6.!rrrrrf")]
		[Test]
		public void CheckPassWordHasUpperCharFailed(string testPassword)
		{
			string errorMessage;
			string testErrorMessage = "Password should contain at least one upper case letter.";
			PasswordValidation passwordValidation = new PasswordValidation();

			passwordValidation.ValidatePassword(testPassword);

			errorMessage = passwordValidation.PasswordError;

			Assert.IsNotNull(errorMessage);
			Assert.AreEqual(errorMessage, testErrorMessage);
		}

		[TestCase("Rrr6!")]
		[Test]
		public void CheckPassWordHasMinCharFailed(string testPassword)
		{
			string errorMessage;
			string testErrorMessage = "Password should not be lesser than 8 or should not be greater than 15 characters.";
			PasswordValidation passwordValidation = new PasswordValidation();

			passwordValidation.ValidatePassword(testPassword);

			errorMessage = passwordValidation.PasswordError;

			Assert.IsNotNull(errorMessage);
			Assert.AreEqual(errorMessage, testErrorMessage);
		}

		[TestCase("Rrr6.!fr%6FS5gdert")]
		[Test]
		public void CheckPassWordHasMaxCharFailed(string testPassword)
		{
			string errorMessage;
			string testErrorMessage = "Password should not be lesser than 8 or should not be greater than 15 characters.";
			PasswordValidation passwordValidation = new PasswordValidation();

			passwordValidation.ValidatePassword(testPassword);

			errorMessage = passwordValidation.PasswordError;

			Assert.IsNotNull(errorMessage);
			Assert.AreEqual(errorMessage, testErrorMessage);
		}

		[TestCase("RP!3TPGDSL")]
		[Test]
		public void CheckPassWordHasLowerCharFailed(string testPassword)
		{
			string errorMessage;
			string testErrorMessage = "Password should contain at least one lower case letter.";
			PasswordValidation passwordValidation = new PasswordValidation();

			passwordValidation.ValidatePassword(testPassword);

			errorMessage = passwordValidation.PasswordError;

			Assert.IsNotNull(errorMessage);
			Assert.AreEqual(errorMessage, testErrorMessage);
		}

		[TestCase("RPn3TPGDSL")]
		[Test]
		public void CheckPassWordHasSymbolCharFailed(string testPassword)
		{
			string errorMessage;
			string testErrorMessage = "Password should contain at least one special case character.";
			PasswordValidation passwordValidation = new PasswordValidation();

			passwordValidation.ValidatePassword(testPassword);

			errorMessage = passwordValidation.PasswordError;

			Assert.IsNotNull(errorMessage);
			Assert.AreEqual(errorMessage, testErrorMessage);
		}
	}
}
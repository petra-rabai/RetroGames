﻿using NUnit.Framework;
using RetroGames;

namespace RetroGamesTests
{
	public class PasswordTests
	{
		[TestCase("Rp!.12846ee")]
		[Test]
		public void CheckIsPasswordValid(string testPassword)
		{
			bool isPasswordValid;
			
			Password password = new Password();
			PasswordValidation passwordValidation = new PasswordValidation();

			password.CheckIsPasswordValid(testPassword,passwordValidation);

			isPasswordValid = password.IsPasswordValid;

			Assert.IsTrue(isPasswordValid);
		}

		[TestCase("Rp!.12846ee")]
		[Test]
		public void CheckIsPasswordEncrypted(string testPassword)
		{
			bool isPasswordEncrypted;

			Password password = new Password();
			PasswordEncrypter passwordEncrypter = new PasswordEncrypter();

			password.CheckIsPasswordEncrypted(testPassword,passwordEncrypter);

			isPasswordEncrypted = password.IsPasswordEncrypted;

			Assert.IsTrue(isPasswordEncrypted);
		}
	}
}
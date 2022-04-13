using FluentAssertions;
using NUnit.Framework;
using RetroGames.Person.Security;

namespace RetroGamesTests
{
	public class StringCryptographerTests
	{
		[TestCase("test")]
		[TestCase("Rp!.x456")]
		[TestCase("123446")]
		[TestCase("Rpx456")]
		[TestCase("!.@/=+")]
		[Test]
		public void IsEncryptedSuccess(string plinText)
		{
			bool testIsEncrypted;

			StringCryptographer stringCryptographer = new();

			stringCryptographer.EncryptProcess(plinText);

			testIsEncrypted = stringCryptographer.IsEncrypted;

			testIsEncrypted.Should().BeTrue();
		}

		[TestCase("test")]
		[TestCase("Rp!.x456")]
		[TestCase("123446")]
		[TestCase("Rpx456")]
		[TestCase("!.@/=+")]
		[Test]
		public void IsDecryptedSuccess(string plaintText)
		{
			bool testIsDecrypted;

			StringCryptographer stringCryptographer = new();
			string encryptedText;
			stringCryptographer.EncryptProcess(plaintText);

			encryptedText = stringCryptographer.EncryptResult;

			stringCryptographer.DecryptProcess(encryptedText);

			testIsDecrypted = stringCryptographer.IsDecrypted;

			testIsDecrypted.Should().BeTrue();
		}

		[TestCase("test")]
		[Test]
		public void EncryptDecryptTextIsEqual(string testPlaintext)
		{
			StringCryptographer stringCryptographer = new();

			stringCryptographer.EncryptProcess(testPlaintext);

			string testEncryptedText = stringCryptographer.EncryptResult;

			stringCryptographer.DecryptProcess(testEncryptedText);

			string testDecryptedText = stringCryptographer.DecryptResult;

			testDecryptedText.Should().Be(testPlaintext);
		}

		[TestCase("")]
		[Test]
		public void CheckIsEncryptedFalse(string test)
		{
			StringCryptographer stringCryptographer = new();
			bool testIsEncrypted;

			testIsEncrypted = stringCryptographer.CheckIsEncrypted(test);

			testIsEncrypted.Should().BeFalse();
		}

		[TestCase("'23455")]
		[Test]
		public void CheckIsEncryptedTrue(string test)
		{
			StringCryptographer stringCryptographer = new();
			bool testIsEncrypted;

			testIsEncrypted = stringCryptographer.CheckIsEncrypted(test);

			testIsEncrypted.Should().BeTrue();
		}

		[TestCase("")]
		[Test]
		public void CheckIsDecryptedFalse(string test)
		{
			StringCryptographer stringCryptographer = new();
			bool testIsDecrypted;

			testIsDecrypted = stringCryptographer.CheckIsDecrypted(test);

			testIsDecrypted.Should().BeFalse();
		}

		[TestCase("'23455")]
		[Test]
		public void CheckIsDecryptedTrue(string test)
		{
			StringCryptographer stringCryptographer = new();
			bool testIsEncrypted;

			testIsEncrypted = stringCryptographer.CheckIsDecrypted(test);

			testIsEncrypted.Should().BeTrue();
		}
	}
}
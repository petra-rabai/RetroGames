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

			stringCryptographer.Encrypt(plinText);

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

			string encryptedText = stringCryptographer.Encrypt(plaintText);

			stringCryptographer.Decrypt(encryptedText);

			testIsDecrypted = stringCryptographer.IsDecrypted;

			testIsDecrypted.Should().BeTrue();
		}

		[TestCase("test")]
		[Test]
		public void EncryptDecryptTextIsEqual(string testPlaintext)
		{
			StringCryptographer stringCryptographer = new();

			string testEncryptedText = stringCryptographer.Encrypt(testPlaintext);
			string testDecryptedText = stringCryptographer.Decrypt(testEncryptedText);

			testDecryptedText.Should().Be(testPlaintext);
		}
	}
}
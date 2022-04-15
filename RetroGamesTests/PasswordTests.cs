using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Security;
using RetroGames.Person.Data;

namespace RetroGamesTests
{
	public class PasswordTests
	{
		[Test]
		public void GetPlayerPasswordSuccess()
		{
			SecureString testSecureString = new NetworkCredential("", "testPassword").SecurePassword;

			Mock<IPassword> mockPassword = new();
			mockPassword
				.Setup(mockSetup => mockSetup.ConvertPasswordToSecure())
				.Returns(() => { return testSecureString; });

			IPassword password = mockPassword.Object;

			password.GetPlayerPassword();

			string testPassword = password.PlayerPassword;

			testPassword.Should().NotBeEmpty();
		}
	}
}
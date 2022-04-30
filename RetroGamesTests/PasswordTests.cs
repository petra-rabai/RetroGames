//using FluentAssertions;
//using Moq;
//using NUnit.Framework;
//using RetroGames.Person.Data;
//using System.Net;
//using System.Security;

//namespace RetroGamesTests
//{
//	public class PasswordTests
//	{
//		[Test]
//		public void GetPlayerPasswordSuccess()
//		{
//			SecureString testSecureString = new NetworkCredential("", "testPassword").SecurePassword;

//			Mock<IPassword> mockPassword = new();
//			mockPassword
//				.Setup(mockSetup => mockSetup.ConvertPasswordToSecure())
//				.Returns(() => { return testSecureString; });

//			IPassword password = mockPassword.Object;

//			password.SetPlayerPassword();

//			string testPassword = password.PlayerPassword;

//			testPassword.Should().NotBeEmpty();
//		}
//	}
//}
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RetroGames.Person.Actions;
using RetroGames.Person.Data;
using RetroGames.Person.Security;

namespace RetroGamesTests
{
	public class EmailTests
	{
		[Test]
		public void CheckGetPlayerEmailSuccess()
		{
			string mockEmail = "test@test.com";

			Mock<IPlayerInteraction> mockPlayerInteraction = new(MockBehavior.Strict);
			mockPlayerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerEmailFromConsole())
				.Returns(() => { return mockEmail; });
			IEmailValidator emailValidator = new EmailValidator();

			Email email = new(emailValidator, mockPlayerInteraction.Object);

			string testEmail = email.GetPlayerEmail();

			testEmail.Should().Be(mockEmail);
		}
	}
}
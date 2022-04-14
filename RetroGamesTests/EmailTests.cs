﻿using FluentAssertions;
using NUnit.Framework;
using RetroGames.Person.Security;
using RetroGames.Person.Data;
using Moq;
using RetroGames;

namespace RetroGamesTests
{
	public class EmailTests
	{
		[Test]
		public void CheckGetPlayerEmailSuccess()
		{
			string mockEmail = "test@test.com";
			string testEmail = "";
			Mock<IPlayerInteraction> mockPlayerInteraction = new(MockBehavior.Strict);
			mockPlayerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerEmailFromConsole())
				.Returns(() => { return mockEmail; });
			IEmailValidator emailValidator = new EmailValidator();

			Email email = new(emailValidator,mockPlayerInteraction.Object);

			testEmail = email.GetPlayerEmail();

			testEmail.Should().Be(mockEmail);
		}
	}
}
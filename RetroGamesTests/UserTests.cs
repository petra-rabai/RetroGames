using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RetroGames;
using RetroGames.Person.Data;

namespace RetroGamesTests
{
	public class UserTests
	{
		[Test]
		public void CheckGetPlayerFirstNameSuccess()
		{
			string mockFirstName = "TestFirstName";
			string testFirstName = "";
			Mock<IPlayerInteraction> mockPlayerInteraction = new(MockBehavior.Strict);
			mockPlayerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerFirstNameFromConsole())
				.Returns(() => { return mockFirstName; });

			User user = new(mockPlayerInteraction.Object);

			testFirstName = user.GetPlayerFirstName();

			testFirstName.Should().Be(mockFirstName);
		}

		[Test]
		public void CheckGetPlayerLastNameSuccess()
		{
			string mockLastName = "TestLastName";
			string testLastName = "";
			Mock<IPlayerInteraction> mockPlayerInteraction = new(MockBehavior.Strict);
			mockPlayerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerLastNameFromConsole())
				.Returns(() => { return mockLastName; });

			User user = new(mockPlayerInteraction.Object);

			testLastName = user.GetPlayerLastName();

			testLastName.Should().Be(mockLastName);
		}

		[Test]
		public void CheckGetPlayerLoginNameSuccess()
		{
			string mockLoginName = "TestLoginName";
			string testLoginName = "";
			Mock<IPlayerInteraction> mockPlayerInteraction = new(MockBehavior.Strict);
			mockPlayerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerLoginNameFromConsole())
				.Returns(() => { return mockLoginName; });

			User user = new(mockPlayerInteraction.Object);

			testLoginName = user.GetPlayerLoginName();

			testLoginName.Should().Be(mockLoginName);
		}
	}
}

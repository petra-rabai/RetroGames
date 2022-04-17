using FluentAssertions;
using Moq;
using NUnit.Framework;
using RetroGames.Person.Actions;
using RetroGames.Person.Data;

namespace RetroGamesTests
{
	public class UserTests
	{
		[Test]
		public void CheckGetPlayerFirstNameSuccess()
		{
			string mockFirstName = "TestFirstName";

			Mock<IPlayerInteraction> mockPlayerInteraction = new(MockBehavior.Strict);
			mockPlayerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerFirstNameFromConsole())
				.Returns(() => { return mockFirstName; });

			User user = new(mockPlayerInteraction.Object);

			string testFirstName = user.GetPlayerFirstName();

			testFirstName.Should().Be(mockFirstName);
		}

		[Test]
		public void CheckGetPlayerLastNameSuccess()
		{
			string mockLastName = "TestLastName";

			Mock<IPlayerInteraction> mockPlayerInteraction = new(MockBehavior.Strict);
			mockPlayerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerLastNameFromConsole())
				.Returns(() => { return mockLastName; });

			User user = new(mockPlayerInteraction.Object);

			string testLastName = user.GetPlayerLastName();

			testLastName.Should().Be(mockLastName);
		}

		[Test]
		public void CheckGetPlayerLoginNameSuccess()
		{
			string mockLoginName = "TestLoginName";

			Mock<IPlayerInteraction> mockPlayerInteraction = new(MockBehavior.Strict);
			mockPlayerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerLoginNameFromConsole())
				.Returns(() => { return mockLoginName; });

			User user = new(mockPlayerInteraction.Object);

			string testLoginName = user.GetPlayerLoginName();

			testLoginName.Should().Be(mockLoginName);
		}
	}
}
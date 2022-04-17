using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;
using NUnit.Framework;
using RetroGames.Person.Actions;
using RetroGames.Game.Actions;
using RetroGames.Game;

namespace RetroGamesTests
{
	public class GameMenuNavigationTests
	{

		[TestCase(' ')]
		[Test]
		public void MenuNavigation_GetMenuFromPlayer(char testKey)
		{
			char mockPlayerKey ='R';

			Mock<IPlayerInteraction> _mockplayerInteraction = new(MockBehavior.Strict);
			_mockplayerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });
			Mock<IMainScreen> mockMainScreen = new();
			mockMainScreen
				.Setup(mockSetup => mockSetup.MainScreenExit())
				.Verifiable();

			GameMenu gameMenu = new();

			GameMenuNavigation gameMenuNavigation = new(_mockplayerInteraction.Object, mockMainScreen.Object, gameMenu);
			
			gameMenuNavigation.PressedKey = testKey;
			
			gameMenuNavigation.MenuNavigation();

			gameMenuNavigation.ChoosedMenu.Should().NotBeEmpty();

		}

		[TestCase('N')]
		[TestCase('I')]
		[TestCase('P')]
		[TestCase('S')]
		[TestCase('D')]
		[TestCase('L')]
		[TestCase('R')]
		[TestCase('H')]
		[TestCase('Q')]
		[Test]
		public void MenuNavigation_Succcess(char testKey)
		{
			char mockPlayerKey = testKey;

			Mock<IPlayerInteraction> _mockplayerInteraction = new(MockBehavior.Strict);
			_mockplayerInteraction
				.Setup(mockSetup => mockSetup.GetPlayerKeyFromConsole())
				.Returns(() => { return mockPlayerKey; });

			Mock<IMainScreen> mockMainScreen = new();
			mockMainScreen
				.Setup(mockSetup => mockSetup.MainScreenExit())
				.Verifiable();

			GameMenu gameMenu = new();

			GameMenuNavigation gameMenuNavigation = new(_mockplayerInteraction.Object,mockMainScreen.Object, gameMenu);

			gameMenuNavigation.PressedKey = testKey;

			gameMenuNavigation.MenuNavigation();

			gameMenuNavigation.isNavigationSuccess.Should().BeTrue();

		}

		

	}
}

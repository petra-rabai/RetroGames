using Moq;
using NUnit.Framework;
using FluentAssertions;
using RetroGames;
using RetroGames.Games;
using RetroGames.Games.Actions;
using RetroGames.Games.DirectoryStructure;
using RetroGames.Games.UI;
using RetroGames.Person.Actions;
using System.IO.Abstractions;

namespace RetroGamesTests
{
	public class InstallationTests
	{
		[Test]
		public void CheckInstallationSuccess()
		{
			bool isInstallationSuccess;

			int mockDrivelistKey = 0;
			string mockDrivelistName = "C:\\";
			Mock<IInstallationUI> mockInstallationUI = new();
			mockInstallationUI
				.Setup(mockSetup => mockSetup.InstallationUIInitialize())
				.Verifiable();
			mockInstallationUI
				.Setup(mockSetup => mockSetup.DrivelistUI(mockDrivelistKey, mockDrivelistName))
				.Verifiable();
		}
	}
}
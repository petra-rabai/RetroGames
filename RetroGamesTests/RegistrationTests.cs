using NUnit.Framework;
using RetroGames;

namespace RetroGamesTests
{
	public class RegistrationTests
	{
		
		[TestCase('Y')]
		[TestCase('N')]
		[Test]
		public void SaveDecesionCheckSuccess(char testDecesion)
		{
			Registration registration = new Registration();
			GameFile gameFile = new GameFile();
			registration.Name = "Test User";
			registration.LoginName = "test";
			registration.Email = "test@test.com";
			registration.Password = "!+563errrv";
			
			registration.SaveDecesionCheck(gameFile,testDecesion);

			Assert.NotNull(registration.IsRegistered);
		}

		[TestCase(true)]
		[TestCase(false)]
		[Test]
		public void IsUserRegisteredSuccess(bool registred)
		{
			Registration registration = new Registration();
			
			registration.IsUserRegistered(registred);

			Assert.AreEqual(registred, registration.IsRegistered);
		}

	}
}

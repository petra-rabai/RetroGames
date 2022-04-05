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
			Drive drive = new Drive();
			GameDirectory gameDirectory = new GameDirectory();
			StringCryptographer stringCryptographer = new StringCryptographer();

			registration.Name = "Test User";
			registration.LoginName = "test1";
			registration.Email = "test@test.com";
			registration.Password = stringCryptographer.Encrypt("Rp!.19840716.!");
			
			registration.SaveDecesionCheck(gameFile,testDecesion,drive,gameDirectory);

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

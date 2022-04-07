using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RetroGames
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IMainScreenUI ImainScreen = new MainScreenUI();
			MainScreen mainScreen = new MainScreen(ImainScreen);
			IUser user = new User();
			IPassword password = new Password();
			IPlayer player = new Player(user,password,registration,login,passwordHandler);
			
			IRegistrationUI registrationUI = new RegistrationUI();
			IDrive drive = new Drive(player);
			IGameFile gameFile = new GameFile();
			IRegistration registration = new Registration();
			
			GameMenuNavigation gameMenuNavigation = new GameMenuNavigation(player);


			mainScreen.MainScreenInitialize();
			gameMenuNavigation.GetChoosedMenu();
			gameMenuNavigation.MenuNavigation();

			Console.ReadLine();

		}
	}
}

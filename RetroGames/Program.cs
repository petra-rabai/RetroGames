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
			MainScreen mainScreen = new MainScreen();
			GameMenu gameMenu = new GameMenu();
			GameMenuNavigation gameMenuNavigation = new GameMenuNavigation();
			Player player = new Player();
			Drive drive = new Drive();
			Registration registration = new Registration();
			GameFile gameFile = new GameFile();
			User user = new User();
			Password password = new Password();
			PasswordEncrypter passwordEncrypter = new PasswordEncrypter();
			PasswordValidation passwordValidation = new PasswordValidation();
			Email playerEmail = new Email();
			EmailValidation emailValidation = new EmailValidation();
			GameDirectory gameDirectory = new GameDirectory();
			Installation installation = new Installation();

			mainScreen.MainScreenInitialize(gameMenu);
			gameMenuNavigation.GetChoosedMenu(gameMenu,player);
			gameMenuNavigation.MenuNavigation(gameMenu, mainScreen, player, drive,registration,gameFile,user,password,playerEmail,installation,gameDirectory,emailValidation,passwordEncrypter,passwordValidation);

			Console.ReadLine();

		}
	}
}

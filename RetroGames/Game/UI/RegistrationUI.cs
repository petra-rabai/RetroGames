using System;

namespace RetroGames
{
	public class RegistrationUI : IRegistrationUI
	{
		private string formContent;

		public void FormTitle()
		{
			Console.Clear();
			SetScreenColor();
			Console.WriteLine("*****************************************************************");
			Console.WriteLine("				New User Registration \n" + "\n ");
			Console.WriteLine("*****************************************************************");
		}

		public void FormFirstName()
		{
			FirstNameUIToConsole();
			Console.WriteLine(formContent + "\n");
		}

		public void FormLastName()
		{
			Console.WriteLine("\n*****************************************************************");
			LastNameUIToConsole();
			Console.WriteLine(formContent + "\n");
		}

		public void FormLoginName()
		{
			Console.WriteLine("\n*****************************************************************");
			LoginNameUIToConsole();
			Console.WriteLine(formContent + "\n");
		}

		public void FormPassword()
		{
			Console.WriteLine("\n*****************************************************************");
			PasswordUIToConsole();
			Console.WriteLine(formContent + "\n");
		}

		public void FormEmail()
		{
			Console.WriteLine("\n*****************************************************************");
			EmailUIToConsole();
			Console.WriteLine(formContent + "\n");
		}

		public void FromSave()
		{
			Console.WriteLine("\n*****************************************************************");
			SaveQuestionUIToConsole();
			Console.WriteLine(formContent + "\n");
		}

		private void SetScreenColor()
		{
			Console.ForegroundColor = ConsoleColor.Green;
		}

		private string LoginNameUIToConsole()
		{
			formContent = " * Login Name: * \n";
			return formContent;
		}

		private string FirstNameUIToConsole()
		{
			formContent = " * First Name: * \n";
			return formContent;
		}

		private string LastNameUIToConsole()
		{
			formContent = " * Last Name: * \n";
			return formContent;
		}

		private string PasswordUIToConsole()
		{
			formContent = " * Password: * \n"
				+ "  Password requirement: \n"
				+ " - Length: minimum 6 character \n"
				+ " - 1 Uppercase letter \n"
				+ " - 1 Lowercase letter \n"
				+ " - Contains number \n"
				+ " - 1 Special character (like . or ! etc) \n";

			return formContent;
		}

		private string EmailUIToConsole()
		{
			formContent = " * E-mail: * \n";
			return formContent;
		}

		private string SaveQuestionUIToConsole()
		{
			formContent = "\n Do you want to save your registration? (Y/N) \n"; ;
			return formContent;
		}
	}
}
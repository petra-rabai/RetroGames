using System;

namespace RetroGames.Game.UI
{
	public class RegistrationUi : IRegistrationUi
	{
		private string _formContent;

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
			_formContent = FirstNameUiToConsole();
			Console.WriteLine(_formContent + "\n");
		}

		public void FormLastName()
		{
			Console.WriteLine("\n*****************************************************************");
			_formContent = LastNameUiToConsole();
			Console.WriteLine(_formContent + "\n");
		}

		public void FormLoginName()
		{
			Console.WriteLine("\n*****************************************************************");
			_formContent = LoginNameUiToConsole();
			Console.WriteLine(_formContent + "\n");
		}

		public void FormPassword()
		{
			Console.WriteLine("\n*****************************************************************");
			_formContent = PasswordUiToConsole();
			Console.WriteLine(_formContent + "\n");
		}

		public void FormEmail()
		{
			Console.WriteLine("\n*****************************************************************");
			_formContent = EmailUiToConsole();
			Console.WriteLine(_formContent + "\n");
		}

		public void FromSave()
		{
			Console.WriteLine("\n*****************************************************************");
			_formContent = SaveQuestionUiToConsole();
			Console.WriteLine(_formContent + "\n");
		}

		private void SetScreenColor()
		{
			Console.ForegroundColor = ConsoleColor.Green;
		}

		private string LoginNameUiToConsole()
		{
			_formContent = " * Login Name: * \n";
			return _formContent;
		}

		private string FirstNameUiToConsole()
		{
			_formContent = " * First Name: * \n";
			return _formContent;
		}

		private string LastNameUiToConsole()
		{
			_formContent = " * Last Name: * \n";
			return _formContent;
		}

		private string PasswordUiToConsole()
		{
			_formContent = " * Password: * \n"
				+ "  Password requirement: \n"
				+ " - Length: minimum 6 character \n"
				+ " - 1 Uppercase letter \n"
				+ " - 1 Lowercase letter \n"
				+ " - Contains number \n"
				+ " - 1 Special character (like . or ! etc) \n";

			return _formContent;
		}

		private string EmailUiToConsole()
		{
			_formContent = " * E-mail: * \n";
			return _formContent;
		}

		private string SaveQuestionUiToConsole()
		{
			_formContent = "\n Do you want to save your registration? (Y/N) \n";
			return _formContent;
		}
	}
}
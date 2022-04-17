using RetroGames.Game.Actions;
using RetroGames.Game.UI;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RetroGames.Game
{
	public class Screen : IScreen
	{
		private readonly IMainScreenUi _mainScreenUi;
		private readonly IGameMenuNavigation _gameMenuNavigation;

		public Screen(IMainScreenUi mainScreenUi, IGameMenuNavigation gameMenuNavigation)
		{
			_mainScreenUi = mainScreenUi;
			_gameMenuNavigation = gameMenuNavigation;
		}

		public bool WaitForUserPromptDisplayed { get; set; }

		[DllImport("kernel32.dll", ExactSpelling = true)]
		private static extern IntPtr GetConsoleWindow();

		private static readonly IntPtr ThisConsole = GetConsoleWindow();

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		private const int Maximize = 3;

		public void MainScreenInitialize()
		{
			GetMainScreenUi();
		}

		public void RegistrationScreenInitialize()
		{
			ScreenSetup();
		}

		public void MainScreenExit()
		{
			Environment.Exit(1);
		}

		private void GetMainScreenUi()
		{
			ScreenSetup();

			_mainScreenUi.InitializeUi();
			WaitForInputSuccess();
		}

		private void ScreenSetup()
		{
			SetScreenColor();
			Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
			ShowWindow(ThisConsole, Maximize);
		}

		private void SetScreenColor()
		{
			switch (_gameMenuNavigation.ChoosedMenu)
			{
				case "New Game":
					Console.ForegroundColor = ConsoleColor.Red;
					break;

				case "Installation":
					Console.ForegroundColor = ConsoleColor.DarkBlue;
					break;

				case "Pause Game":
					Console.ForegroundColor = ConsoleColor.Cyan;
					break;

				case "Save Game":
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;

				case "Load Game":
					Console.ForegroundColor = ConsoleColor.DarkRed;
					break;

				case "Login":
					Console.ForegroundColor = ConsoleColor.Blue;
					break;

				case "Registration":
					Console.ForegroundColor = ConsoleColor.Green;

					break;

				case "Help":
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					break;

				default:
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
			}
			
		}

		public bool WaitForInputSuccess()
		{
			while (FlashPrompt(" *** Wait for user input ... (Hit Enter to Continue)",
			TimeSpan.FromMilliseconds(500)) != ConsoleKey.Enter)

				WaitForUserPromptDisplayed = true;

			return WaitForUserPromptDisplayed;
		}

		private ConsoleKey FlashPrompt(string prompt, TimeSpan interval)
		{
			var cursorTop = Console.CursorTop;
			var colorOne = Console.ForegroundColor;
			var colorTwo = Console.BackgroundColor;

			var stopwatch = Stopwatch.StartNew();
			var lastValue = TimeSpan.Zero;

			Console.Write(prompt);

			while (!Console.KeyAvailable)
			{
				var currentValue = stopwatch.Elapsed;

				if (currentValue - lastValue < interval) continue;

				lastValue = currentValue;
				Console.ForegroundColor = Console.ForegroundColor == colorOne
					? colorTwo : colorOne;
				Console.BackgroundColor = Console.BackgroundColor == colorOne
					? colorTwo : colorOne;
				Console.SetCursorPosition(0, cursorTop);
				Console.CursorSize = 80;
				Console.Write(" " + prompt);
			}

			Console.ForegroundColor = colorOne;
			Console.BackgroundColor = colorTwo;

			return Console.ReadKey(true).Key;
		}
	}
}
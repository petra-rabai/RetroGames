using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class MainScreen
	{
		MainScreenUI MainScreenUI { get; set; } = new MainScreenUI();
		public bool WaitForUserPromptDisplayed { get; set; }

		[DllImport("kernel32.dll", ExactSpelling = true)]
		private static extern IntPtr GetConsoleWindow();
		private static IntPtr ThisConsole = GetConsoleWindow();
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		private const int HIDE = 0;
		private const int MAXIMIZE = 3;
		private const int MINIMIZE = 6;
		private const int RESTORE = 9;


		public void MainScreenInitialize(GameMenu gameMenu)
		{
			GetMainScreenUI(gameMenu);
		}

		private void GetMainScreenUI(GameMenu gameMenu)
		{
			MainScreenSetup();
			MainScreenUI.InitializeMainScreenUI(gameMenu);
			WaitForInput();
		}

		private void MainScreenSetup()
		{
			SetScreenColor();
			Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
			ShowWindow(ThisConsole, MAXIMIZE);	
		}

		private void SetScreenColor()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
		}

		public bool WaitForInput()
		{
			while (FlashPrompt(" *** Wait for user input ... (Hit Enter to Continue)",
			TimeSpan.FromMilliseconds(500)) != ConsoleKey.Enter) ;

			WaitForUserPromptDisplayed = true;

			return WaitForUserPromptDisplayed;

		}

		private ConsoleKey FlashPrompt(string prompt, TimeSpan interval)
		{

			var cursorTop = Console.CursorTop;
			var colorOne = Console.ForegroundColor;
			var colorTwo = Console.BackgroundColor;

			var stopwach = Stopwatch.StartNew();
			var lastValue = TimeSpan.Zero;


			Console.Write(prompt);

			while (!Console.KeyAvailable)
			{
				var currentValue = stopwach.Elapsed;


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

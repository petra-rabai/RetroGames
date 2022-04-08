﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class PlayerInteraction : IPlayerInteraction
	{
		public char PressedKey { get; set; }

		public char GetPlayerKeyFromConsole()
		{
			ConsoleKeyInfo hitkey = Console.ReadKey();

			if (hitkey.Key == ConsoleKey.D0
				|| hitkey.Key == ConsoleKey.D1
				|| hitkey.Key == ConsoleKey.D2
				|| hitkey.Key == ConsoleKey.D3
				|| hitkey.Key == ConsoleKey.D4
				|| hitkey.Key == ConsoleKey.D5)
			{
				string numKey = hitkey.Key.ToString();
				string[] numKeyValue = new string[1];
				numKeyValue[0] = numKey.Split('D').Last();
				PressedKey = Convert.ToChar(numKeyValue[0]);
			}
			else
			{
				PressedKey = Char.Parse(hitkey.Key.ToString());
			}
			return PressedKey;
		}
	}
}
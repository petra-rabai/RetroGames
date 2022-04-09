using System;

namespace RetroGames.Games.UI
{
	public class InstallationUI : IInstallationUI
	{
		public void InstallationUIInitialize()
		{
			Console.Clear();
			SetScreenColor();
			Console.WriteLine("\n\tWelcome to the Installation screen."
					 + "\n\tThe installation process check the available drive space on the System."
					 + "\n\tIf you want to install the game to the default drive hit the * key."
					 + "\n\tIf you want to different installation location please select a drive from the list: ");
			Console.WriteLine("\n\tHit the number of the disc where do you want to install the game.\n");
			Console.WriteLine("\n\tIf you want to skip the Installation process hit the K key.\n");
		}

		private void SetScreenColor()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
		}

		public void DrivelistUI(int key, string driveName)
		{
			Console.WriteLine("\n\t" + key + " - " + driveName + "\n");
		}
	}
}
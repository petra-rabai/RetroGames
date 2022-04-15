using System;

namespace RetroGames.Game.UI
{
	public class InstallationUi : IInstallationUi
	{
		private const string InstallationWelcomeMessage = "\n\tWelcome to the Installation screen."
							 + "\n\tThe installation process check the available drive space on the System."
							 + "\n\tIf you want to install the game to the default drive hit the * key."
							 + "\n\tIf you want to different installation location please select a drive from the list: "
							 + "\n\tHit the number of the disc where do you want to install the game.\n"
							 + "\n\tIf you want to skip the Installation process hit the K key.\n";

		public void InstallationUiInitialize()
		{
			Console.Clear();
			SetScreenColor();
			Console.WriteLine(InstallationWelcomeMessage);
		}

		private void SetScreenColor()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
		}

		public void DrivelistUi(int key, string driveName)
		{
			Console.WriteLine("\n\t" + key + " - " + driveName + "\n");
		}
	}
}
using System;

namespace RetroGames.Game.UI
{
	public class InstallationUi : IInstallationUi
	{
		private readonly IScreen _screen;

		private const string _installationWelcomeMessage = "\n\tWelcome to the Installation screen."
							 + "\n\tThe installation process check the available drive space on the System."
							 + "\n\tIf you want to install the game to the default drive hit the O key."
							 + "\n\tIf you want to different installation location please select a drive from the list: "
							 + "\n\tHit the Id number of the disc where do you want to install the game.\n"
							 + "\n\tIf you want to skip the Installation process hit the K key.\n";

		public InstallationUi(IScreen screen)
		{
			_screen = screen;
		}

		public void InstallationUiInitialize()
		{
			Console.Clear();
			Console.WriteLine(_installationWelcomeMessage);
		}
		
		
		public void HddListUi(int key, string driveName)
		{
			Console.WriteLine("\n\t" + key + " - " + driveName + "\n");
		}

		public void Wait()
		{
			_screen.WaitForInputSuccess();
		}


	}
}
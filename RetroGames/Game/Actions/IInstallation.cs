﻿namespace RetroGames.Game.Actions
{
	public interface IInstallation
	{
		bool IsInstallationSuccess { get; set; }
		string GameFilePath { get; set; }
		string UserFilePath { get; set; }
		string LogFilePath { get; set; }
		char PlayerPressedKey { get; set; }
		
		void InstallationProcess();

		bool CheckInstallationSuccess();
	}
}
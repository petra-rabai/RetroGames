using RetroGames.Game.Structure.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames.Game.Structure
{
	public class GameStructure : IGameStructure
	{
		private readonly IGameFile _gameFile;
		private readonly IUserFile _userFile;
		private readonly ILogFile _logFile;

		public GameStructure(IGameFile gameFile, IUserFile userFile, ILogFile logFile)
		{
			_gameFile = gameFile;
			_userFile = userFile;
			_logFile = logFile;
		}

		public void Initialize()
		{
			_gameFile.CreateGameFile();
			_userFile.CreateUserFile();
			_logFile.CreateLogFile();
		}
	}
}

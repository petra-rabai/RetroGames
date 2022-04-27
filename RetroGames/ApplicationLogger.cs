using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class ApplicationLogger
	{
		readonly ILogger _log;

		public ApplicationLogger(ILogger log)
		{
			_log = log;
		}


	}
}

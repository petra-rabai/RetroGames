using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class MainService : IMainService
	{
		private readonly ILogger<MainService> _log;
		private readonly IConfiguration _conifg;
		private readonly IApplicationService _applicationService;

		public MainService(ILogger<MainService> log, IConfiguration conifg, IApplicationService applicationService)
		{
			_log = log;
			_conifg = conifg;
			_applicationService = applicationService;
		}

		public void Initialize()
		{
			_log.LogInformation("Application service start...");
			_applicationService.Initilaize();
			_log.LogInformation("Application service finished successful");
		}

	}
}

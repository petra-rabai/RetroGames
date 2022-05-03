using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace RetroGames
{
	internal class Program
	{
		private static void Main()
		{
			ApplicationServiceStart();
		}

		private static void ApplicationServiceStart()
		{
			ApplicationService applicationService = new();
			applicationService.Initilaize();
		}

	}
}
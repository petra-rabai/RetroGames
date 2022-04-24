using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class ApplicationService
	{

		IContainer iOcContainer = ContainerConfig.Configure();
		ILifetimeScope scope = iOcContainer.BeginLifetimeScope();

		IApplication application = scope.Resolve<IApplication>();

		application.Run();
	}
}

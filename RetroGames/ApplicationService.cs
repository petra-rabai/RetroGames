using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class ApplicationService : IApplicationService
	{

		public void Initilaize()
		{
			IContainer iOcContainer = ConfigureContainer();

			ILifetimeScope scope = LifetimeStart(iOcContainer);
			
			IApplication application = ResolveScopeStrat(scope);

			application.Run();
		}

		private static IApplication ResolveScopeStrat(ILifetimeScope scope)
		{
			return scope.Resolve<IApplication>();
		}

		private static ILifetimeScope LifetimeStart(IContainer iOcContainer)
		{
			return iOcContainer.BeginLifetimeScope();
		}

		private static IContainer ConfigureContainer()
		{
			return ContainerConfig.Configure();
		}
	}
}

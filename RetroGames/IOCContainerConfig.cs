using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGames
{
	public class IOCContainerConfig
	{
		public IContainer Configure()
		{
			ContainerBuilder containerBuilder = new ContainerBuilder();
			containerBuilder.RegisterType<Drive>().As<IDrive>();

			return containerBuilder.Build();
		}
	}
}

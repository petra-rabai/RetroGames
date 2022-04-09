using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NUnit.Framework;
using RetroGames;

namespace RetroGamesTests
{
	public class IOCContainerConfigTests
	{
		protected ILifetimeScope Scope { get; set; }

		[SetUp]
		public void Setup()
		{
			ContainerBuilder Builder = new ContainerBuilder();
			IContainer iOCContainer = iOCContainerConfig.Configure();
			Builder.RegisterModule<>();
			IContainer container = Builder.Build();
		}
	}
}

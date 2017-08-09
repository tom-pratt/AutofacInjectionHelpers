using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sylapse.AutofacPlatformInjection
{
    public class AppRoot
    {
        public static IContainer Container { get; private set; }

        private readonly IList<ISetup> _setups = new List<ISetup>();

        public AppRoot()
        {
            System.Diagnostics.Debug.WriteLine("APPROOT CONSTRUCTOR");
        }

        public void Initialize()
        {
            System.Diagnostics.Debug.WriteLine("APPROOT CONSTRUCTOR");
            var builder = new ContainerBuilder();

            foreach (var setup in _setups)
            {
                setup.Initialize(builder);
            }

            Container = builder.Build();
        }

        public void Add(ISetup setup)
        {
            _setups.Add(setup);
        }
    }
}

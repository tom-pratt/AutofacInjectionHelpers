using Sylapse.AutofacPlatformInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace MainSample
{
    public class CoreSetup : ISetup
    {
        public void Initialize(ContainerBuilder builder)
        {
            builder.RegisterType<FirstViewModel>();
        }
    }
}

using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sylapse.AutofacPlatformInjection
{
    public interface ISetup
    {
        void Initialize(ContainerBuilder builder);
    }
}

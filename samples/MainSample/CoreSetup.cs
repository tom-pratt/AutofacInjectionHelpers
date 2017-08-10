using Sylapse.AutofacPlatformInjection;
using Autofac;

namespace MainSample
{
    public class CoreSetup : ISetup
    {
        public void Initialize(ContainerBuilder builder)
        {
            // Make objects survive an Android rotations by scoping them as InstancePerViewLifetime
            builder.RegisterType<MainViewModel>().InstancePerViewLifetime();
            builder.RegisterType<FirstViewModel>().InstancePerViewInstance();
        }
    }
}

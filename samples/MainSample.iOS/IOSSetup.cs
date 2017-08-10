using Autofac;
using Sylapse.AutofacPlatformInjection;

namespace MainSample.iOS
{
    public class IOSSetup : ISetup
    {
        private readonly AppDelegate _appDelegate;

        public IOSSetup(AppDelegate appDelegate)
        {
            _appDelegate = appDelegate;
        }
        public void Initialize(ContainerBuilder builder)
        {
            builder.RegisterInstance(_appDelegate);

            // It's best if types that inherit from an Android base class dont't call
            // Dispose as it's used by Xamarin. So call a "Finish" method instead.
            //builder.RegisterType<ItemsAdapter>().OnRelease(a => a.Finish());
            //builder.RegisterType<ItemViewHolder>().OnRelease(a => a.Finish());
        }
    }
}
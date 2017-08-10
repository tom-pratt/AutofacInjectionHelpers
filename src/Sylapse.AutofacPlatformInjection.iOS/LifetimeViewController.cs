using System;
using Autofac;
using UIKit;
using Sylapse.AutofacLateInjection;

namespace Sylapse.AutofacPlatformInjection.iOS
{
    public class LifetimeViewController : UIViewController
	{
		private ILifetimeScope _viewLifetimeScope;
		private ILifetimeScope _viewInstanceScope;
		private ILifetimeScope _viewLayoutScope;

		public LifetimeViewController() : base()
		{
		}

		public LifetimeViewController(IntPtr handle) : base(handle)
		{
		}

        public override void ViewDidLoad()
        {
			base.ViewDidLoad();

			_viewLifetimeScope = AppRoot.Container.BeginViewLifetimeScope();
			_viewInstanceScope = _viewLifetimeScope.BeginViewInstanceScope(builder =>
			{
				builder.RegisterInstance(this).As<UIViewController>().ExternallyOwned();
			});
			_viewLayoutScope = _viewInstanceScope.BeginViewLayoutScope();

            _viewLayoutScope.Inject(this, InjectionPoints.ViewDidLoad);
		}

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            if (IsMovingFromParentViewController) {
                _viewLayoutScope?.Dispose();
                _viewInstanceScope?.Dispose();
                _viewLifetimeScope?.Dispose();
            }
        }
    }
}

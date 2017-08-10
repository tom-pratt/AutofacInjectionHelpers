using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Autofac;
using Sylapse.AutofacLateInjection;

namespace Sylapse.AutofacPlatformInjection.Droid
{
    public class LifetimeActivity : AppCompatActivity
    {
        private const string StateLifetimeTag = "statelifetimetag";

        ScopeFragment _scopeFragment;

        private ILifetimeScope _viewInstanceScope;
        private ILifetimeScope _viewLayoutScope;

        private string _lifetimeTag;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _lifetimeTag = savedInstanceState == null ? Guid.NewGuid().ToString() : savedInstanceState.GetString(StateLifetimeTag);
            _scopeFragment = (ScopeFragment)SupportFragmentManager.FindFragmentByTag(_lifetimeTag);

            if (_scopeFragment == null)
            {
                _scopeFragment = new ScopeFragment();
                SupportFragmentManager.BeginTransaction().Add(_scopeFragment, _lifetimeTag).Commit();
            }

            _viewInstanceScope = _scopeFragment.Scope.BeginViewInstanceScope(builder =>
            {
                builder.RegisterInstance(this).As<Activity>().ExternallyOwned();
                builder.RegisterInstance(LayoutInflater.From(this)).ExternallyOwned();
            });            
            _viewLayoutScope = _viewInstanceScope.BeginViewLayoutScope();

            _viewInstanceScope.Inject(this, InjectionPoints.OnCreate);
            _viewLayoutScope.Inject(this, InjectionPoints.OnCreate);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutString(StateLifetimeTag, _lifetimeTag);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _viewLayoutScope?.Dispose();
            _viewInstanceScope.Dispose();

            if (IsFinishing)
            {
                SupportFragmentManager.BeginTransaction().Remove(_scopeFragment).Commit();
            }
        }
    }
}
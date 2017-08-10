using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Autofac;
using Sylapse.AutofacLateInjection;

namespace Sylapse.AutofacPlatformInjection.Droid
{
    public class LifetimeFragment : Android.Support.V4.App.Fragment
    {
        private const string StateLifetimeTag = "statelifetimetag";

        ScopeFragment _scopeFragment;
        bool _isSaving;
        bool _onCreateViewWasCalled;

        private ILifetimeScope _viewInstanceScope;
        private ILifetimeScope _viewLayoutScope;


        private string _lifetimeTag;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _lifetimeTag = savedInstanceState == null ? Guid.NewGuid().ToString() : savedInstanceState.GetString(StateLifetimeTag);
            _scopeFragment = (ScopeFragment)FragmentManager.FindFragmentByTag(_lifetimeTag);

            if (_scopeFragment == null)
            {
                _scopeFragment = new ScopeFragment();
                FragmentManager.BeginTransaction().Add(_scopeFragment, _lifetimeTag).Commit();
            }

            _viewInstanceScope = _scopeFragment.Scope.BeginViewInstanceScope(builder =>
            {
                builder.RegisterInstance(Activity).As<Activity>().ExternallyOwned();
                builder.RegisterInstance(LayoutInflater.From(Activity)).ExternallyOwned();
                builder.RegisterInstance(this).As<Android.Support.V4.App.Fragment>().ExternallyOwned();
            });

            _viewInstanceScope.Inject(this, InjectionPoints.OnCreate);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _onCreateViewWasCalled = true;
            _viewLayoutScope = _viewInstanceScope.BeginViewLayoutScope();
            _viewLayoutScope.Inject(this, InjectionPoints.OnCreateView);
            return null;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            if (!_onCreateViewWasCalled)
                throw new InvalidOperationException("When inheriting from RetainedLifetimeFragment, must call base.OnCreateView.");
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutString(StateLifetimeTag, _lifetimeTag);
            _isSaving = true;
        }

        public override void OnDetach()
        {
            base.OnDetach();
            // If a fragment is being removed but not saved then we can assume it is being popped. So we remove its associated RetainInstance fragment and the ILifetimeScope is disposed
            if (IsRemoving && !_isSaving)
            {
                FragmentManager.BeginTransaction().Remove(_scopeFragment).Commit();
            }
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            _viewLayoutScope?.Dispose();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            _viewInstanceScope.Dispose();
        }
    }
}
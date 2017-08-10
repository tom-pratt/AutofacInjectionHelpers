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

namespace Sylapse.AutofacPlatformInjection.Droid
{
    public class ScopeFragment : Android.Support.V4.App.Fragment
    {
        public ILifetimeScope Scope { get; }

        public ScopeFragment()
        {
            Scope = AppRoot.Container.BeginViewLifetimeScope();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Scope.Dispose();
        }
    }
}
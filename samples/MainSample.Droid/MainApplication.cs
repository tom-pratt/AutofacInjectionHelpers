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
using Sylapse.AutofacPlatformInjection;

namespace MainSample.Droid
{
    [Application(Theme = "@style/MyTheme", Icon = "@drawable/Icon")]
    public class MainApplication : Android.App.Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            var appRoot = new AppRoot();
            appRoot.Add(new CoreSetup());
            appRoot.Add(new DroidSetup(this));
            appRoot.Initialize();
        }
    }
}
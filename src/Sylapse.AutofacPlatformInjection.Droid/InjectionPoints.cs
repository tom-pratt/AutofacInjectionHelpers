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

namespace Sylapse.AutofacPlatformInjection.Droid
{
    public static class InjectionPoints
    {
        public const string OnCreate = "oncreate";
        public const string OnCreateView = "oncreateview";
    }
}
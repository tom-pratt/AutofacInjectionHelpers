﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Sylapse.AutofacLateInjection;

namespace Sylapse.AutofacPlatformInjection.Droid
{
    public class InjectOnCreateAttribute : InjectAttribute
    {
        public InjectOnCreateAttribute() : base(InjectionPoints.OnCreate)
        {
        }
    }

    public class InjectOnCreateViewAttribute : InjectAttribute
    {
        public InjectOnCreateViewAttribute() : base(InjectionPoints.OnCreateView)
        {
        }
    }
}
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
using Sylapse.AutofacPlatformInjection;

namespace MainSample.Droid
{
    public class DroidSetup : ISetup
    {
        private readonly Context _context;

        public DroidSetup(Context context)
        {
            _context = context;
        }
        public void Initialize(ContainerBuilder builder)
        {
            builder.RegisterInstance(_context);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Sylapse.AutofacPlatformInjection.Droid;

namespace MainSample.Droid
{
    public class FirstFragment : LifetimeFragment
    {
        [InjectOnCreate]
        private FirstViewModel _firstViewModel;

        private TextView _textView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // ViewModel is ready at this point
            Activity.Title = _firstViewModel.Title;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Must call base when using LifetimeFragment
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.FirstFragment, container, false);
            _textView = view.FindViewById<TextView>(Resource.Id.textView1);
            
            // Bind views to view model using preferred technique (e.g. MvvmLight etc)
            _textView.Text = _firstViewModel.Title;

            return view;
        }
    }
}
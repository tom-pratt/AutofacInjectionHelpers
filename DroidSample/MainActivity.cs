using Android.App;
using Android.Widget;
using Android.OS;
using Sylapse.AutofacPlatformInjection.Droid;

namespace MainSample.Droid
{
    [Activity(Label = "MainSample.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : LifetimeActivity
    {
        [InjectOnCreate]
        private MainViewModel _mainViewModel;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.MainActivity);

            Toast.MakeText(this, _mainViewModel.Message, ToastLength.Long).Show();

            if (bundle == null)
            {
                SupportFragmentManager.BeginTransaction()
                    .Add(Resource.Id.FragmentContainer, new FirstFragment(), null)
                    .Commit();
            }
        }
    }
}


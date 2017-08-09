using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace MainSample.Droid
{
    [Activity(Label = "MainSample.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.MainActivity);

            if (bundle == null)
            {
                SupportFragmentManager.BeginTransaction()
                    .Add(Resource.Id.FragmentContainer, new FirstFragment(), null)
                    .Commit();
            }
        }
    }
}


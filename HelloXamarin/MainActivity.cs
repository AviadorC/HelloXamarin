using Android.App;
using Android.Widget;
using Android.OS;

namespace HelloXamarin
{
    [Activity(Label = "HelloXamarin", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Holo.NoActionBar")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = Resources.GetString(Resource.String.ButtonClicked); };
        }
    }
}


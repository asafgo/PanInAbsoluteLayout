using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Content.Res;

namespace PanInAbsoluteLayout.Droid
{
    [Activity(Label = "PanInAbsoluteLayout", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            var width = Resources.DisplayMetrics.WidthPixels;
            var height = Resources.DisplayMetrics.HeightPixels;
            var density = Resources.DisplayMetrics.Density;
            App.ScreenWidth = (width - 0.5f) / density;
            App.ScreenHeight = (height - 0.5f) / density;
            //App.StatusBarHeight = getStatusBarHeight();
            App.StatusBarHeight = 0;
            App.NavigationBarHeight = getNavigationBarHeight();

            LoadApplication(new App());
        }

        private int getStatusBarHeight()
        {
            Resources res = this.Resources;
            int resourceId = res.GetIdentifier("status_bar_height", "dimen", "android");
            int height = res.GetDimensionPixelSize(resourceId);
            return height;
        }

        private int getNavigationBarHeight()
        {
            Resources res = this.Resources;
            int resourceId = res.GetIdentifier("navigation_bar_height", "dimen", "android");
            int height = res.GetDimensionPixelSize(resourceId);
            return height;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
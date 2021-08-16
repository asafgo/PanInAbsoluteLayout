using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PanInAbsoluteLayout
{
    public partial class App : Application
    {
        public static double ScreenWidth;
        public static double ScreenHeight;
        public static int StatusBarHeight;
        public static int NavigationBarHeight;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

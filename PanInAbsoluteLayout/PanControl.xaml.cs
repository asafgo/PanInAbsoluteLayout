using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PanInAbsoluteLayout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PanControl : ContentView
    {
        double x, y;
        public PanGestureRecognizer PanGestureRecognizer { get; set; }

        public PanControl()
        {
            InitializeComponent();

            PanGestureRecognizer = new PanGestureRecognizer
            {
                TouchPoints = 1
            };
            PanGestureRecognizer.PanUpdated += PanGestureRecognizer_PanUpdated;
            GestureRecognizers.Add(PanGestureRecognizer);
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            //switch (e.StatusType)
            //{
            //    case GestureStatus.Running:
            //        TranslationX = (Device.RuntimePlatform == Device.Android ? TranslationX : 0) + e.TotalX;
            //        TranslationY = (Device.RuntimePlatform == Device.Android ? TranslationY : 0) + e.TotalY;
            //        break;

            //    case GestureStatus.Completed:
            //        x = Content.TranslationX;
            //        y = Content.TranslationY;
            //        break;
            //}

            PanControl pan = (PanControl)sender;
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    double a = pan.TranslationX + e.TotalX;
                    double b = pan.TranslationY + e.TotalY;
                    pan.TranslationX = a < 0 ? 0 : (a > (App.ScreenWidth - pan.Width) ? (App.ScreenWidth - pan.Width) : a);
                    pan.TranslationY = b < 0 ? 0 : (b > (App.ScreenHeight - App.StatusBarHeight - App.NavigationBarHeight - pan.Height - 50)
                        ? (App.ScreenHeight - App.StatusBarHeight - App.NavigationBarHeight - pan.Height - 50) : b); // 50 is <RowDefinition Height="50" /> at MainPage.xaml

                    break;

                case GestureStatus.Completed:
                    break;
            }
        }


        private double valueX, valueY;
        private bool IsTurnX, IsTurnY;
        private void PanGestureRecognizer_PanUpdated_Left_Right_Up_Down(object sender, PanUpdatedEventArgs e)
        {
            //var xxx = e.TotalX;
            //this.WidthRequest = this.Width + e.TotalX / 2;

            var x = e.TotalX; // TotalX Left/Right
            var y = e.TotalY; // TotalY Up/Down

            // StatusType
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    Console.WriteLine("Started");
                    break;
                case GestureStatus.Running:
                    Console.WriteLine("Running");

                    // Check that the movement is x or y
                    if ((x >= 5 || x <= -5) && !IsTurnX && !IsTurnY)
                    {
                        IsTurnX = true;
                    }

                    if ((y >= 5 || y <= -5) && !IsTurnY && !IsTurnX)
                    {
                        IsTurnY = true;
                    }

                    // X (Horizontal)
                    if (IsTurnX && !IsTurnY)
                    {
                        if (x <= valueX)
                        {
                            // Left
                            if (frmMain.WidthRequest <= 100)
                            {
                                frmMain.WidthRequest = 100;
                            }
                            frmMain.WidthRequest += 10;
                        }

                        if (x >= valueX)
                        {
                            // Right

                            if (frmMain.WidthRequest <= 100)
                            {
                                frmMain.WidthRequest = 100;
                            }
                            frmMain.WidthRequest -= 10;
                        }
                    }

                    // Y (Vertical)
                    if (IsTurnY && !IsTurnX)
                    {
                        if (y <= valueY)
                        {
                            // Up

                            if (frmMain.HeightRequest <= 100)
                            {
                                frmMain.HeightRequest = 100;
                            }
                            frmMain.HeightRequest += 5;
                        }

                        if (y >= valueY)
                        {
                            // Down

                            if (frmMain.HeightRequest <= 100)
                            {
                                frmMain.HeightRequest = 100;
                            }
                            frmMain.HeightRequest -= 5;
                        }
                    }

                    break;
                case GestureStatus.Completed:
                    Console.WriteLine("Completed");

                    valueX = x;
                    valueY = y;

                    IsTurnX = false;
                    IsTurnY = false;

                    break;
                case GestureStatus.Canceled:
                    Console.WriteLine("Canceled");
                    break;
            }
        }

    }
}
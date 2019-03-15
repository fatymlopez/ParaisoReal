using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ParaisoRealB.View
{
    public class SplashScreenR : ContentPage
    {
        Image LogoSplash;
        public SplashScreenR()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();
            LogoSplash = new Image
            {
                Source = "Logo.png",
                WidthRequest  = 300,
                HeightRequest = 300

            };

            AbsoluteLayout.SetLayoutFlags(LogoSplash, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(LogoSplash, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            sub.Children.Add(LogoSplash);

            this.BackgroundColor = Color.White;
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await LogoSplash.ScaleTo(1, 2000);
            await LogoSplash.ScaleTo(0.9, 1500, Easing.Linear);
            //await LogoSplash.ScaleTo(150, 1200, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new Inicio());

        }
    }
}

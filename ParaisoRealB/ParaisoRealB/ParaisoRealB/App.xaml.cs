﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ParaisoRealB.View;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ParaisoRealB
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var navigationPage = new NavigationPage(new Inicio());
            
            navigationPage.BarBackgroundColor = Color.Black;
            
            navigationPage.BarTextColor = Color.Gray;
            MainPage = navigationPage;

          


          
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

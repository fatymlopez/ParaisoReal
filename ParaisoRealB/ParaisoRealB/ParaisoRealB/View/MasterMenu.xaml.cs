﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ParaisoRealB.View;
using ParaisoRealB.Model;

namespace ParaisoRealB.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMenu : MasterDetailPage
    {
        public MasterMenu()
        {
            InitializeComponent();


        }
        protected override void OnAppearing()
         {
             base.OnAppearing();

            MasterBehavior = MasterBehavior.Popover;
            IsPresented = false;

         }


        


    }
}
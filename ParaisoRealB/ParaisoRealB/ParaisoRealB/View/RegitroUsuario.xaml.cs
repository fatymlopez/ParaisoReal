﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParaisoRealB.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegitroUsuario : ContentPage
	{
		public RegitroUsuario ()
		{
			InitializeComponent ();
		}

        

        public void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
        {
            Password.IsPassword = Password.IsPassword ? false : true;
        }
    }
}
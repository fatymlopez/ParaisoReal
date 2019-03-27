using ParaisoRealB.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParaisoRealB.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Ordenar : ContentPage
	{
		public Ordenar ()
		{
			InitializeComponent ();
		}

        public void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            

            double value = e.NewValue;
            //price.Text = string.Format("Total {0}" , value);
            cant.Text = string.Format("Cantidad {0}", value);

          //decimal  p1 = Convert.ToDecimal(price.Text.ToString());
          //double  p2 = Convert.ToDouble(cant.Text.ToString());
          //  double total = Convert.ToDouble(ttal.Text.ToString());
          //  total = p1 * p2;


        }

        public void BtnOrdenar_Clicked(object sender, EventArgs e)
        {

        }
    }
}
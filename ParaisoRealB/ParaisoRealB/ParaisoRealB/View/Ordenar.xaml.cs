using Newtonsoft.Json;
using ParaisoRealB.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            cant.Text = string.Format("{0}", value);




        }

        public async void BtnOrdenar_Clicked(object sender, EventArgs e)
        {
            // double p1 = Convert.ToDouble(price.Text.ToString());
            //double p2 = Convert.ToDouble(cant.Text.ToString());
            //double total = Convert.ToDouble(ttal.Text.ToString());
            //total = p1 * p2;



            reservacion newreserva = new reservacion()
            {
                cantidad = Convert.ToInt32(cant.Text.ToString())

            };

            var json = JsonConvert.SerializeObject(newreserva);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PostAsync("http://paraisoreal19.somee.com/api/reservacions/Postreservacion", content);

            if (result.StatusCode == HttpStatusCode.Created)
            {
                await App.Current.MainPage.DisplayAlert("Genial!", " Tu registro se ha realizado con exito", "Ok");





            }
        }
    }
}
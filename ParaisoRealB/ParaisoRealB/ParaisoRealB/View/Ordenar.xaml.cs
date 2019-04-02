using Newtonsoft.Json;
using ParaisoRealB.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        //Model.Modeldb.productos product;

        public Ordenar()
        {
            InitializeComponent();         

            //product = BindingContext as Model.Modeldb.productos;
        }



        public void Btnvertotal_Clicked(object sender, EventArgs e)
        {
            decimal p1 = Convert.ToDecimal(price.Text.ToString());
            int p2 = Convert.ToInt32(cantidad.Text.ToString());

            decimal p3;
            p3 = p1 * p2;
            cantidadtxt.Text = "Cantidad a ordenar:" + p2;
            Total.Text = "Su Total es de:" + p3;

            reservacion newreservacion = new reservacion()
            {
               

                

            };

        }

        public async void BtnOrdenar_Clicked(object sender, EventArgs e)
        {
           


        }


        //private decimal precio_BF;

        //public decimal precio
        //{
        //    get { return precio_BF; }
        //    set {
        //        precio_BF = Convert.ToDecimal(NumPlatos) * product.precio;
        //        OnPropertyChanged();
        //    }
        //}

        //private double NumPlatos_BF;

        //public double NumPlatos
        //{
        //    get { return NumPlatos_BF; }
        //    set { NumPlatos_BF = value; }
        //}

        //public void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        //{

        //    double value = e.NewValue;

        //    cant.Text = string.Format("{0}", value);




        //}

        //public async void BtnOrdenar_Clicked(object sender, EventArgs e)
        //{
        //    //// double p1 = Convert.ToDouble(price.Text.ToString());
        ////double p2 = Convert.ToDouble(cant.Text.ToString());
        ////double total = Convert.ToDouble(ttal.Text.ToString());
        ////total = p1 * p2;



        //reservacion newreserva = new reservacion()
        //{
        //    cantidad = Convert.ToInt32(cant.Text.ToString())

        //};

        //var json = JsonConvert.SerializeObject(newreserva);
        //var content = new StringContent(json, Encoding.UTF8, "application/json");
        //HttpClient client = new HttpClient();
        //var result = await client.PostAsync("http://paraisoreal19.somee.com/api/reservacions/Postreservacion", content);

        //if (result.StatusCode == HttpStatusCode.Created)
        //{
        //    await App.Current.MainPage.DisplayAlert("Genial!", " Tu registro se ha realizado con exito", "Ok");





        //}
        //}
    }
}
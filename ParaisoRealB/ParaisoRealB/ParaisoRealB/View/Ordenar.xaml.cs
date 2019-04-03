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
        public Ordenar()
        {
            InitializeComponent();

            //decimal p1 = Convert.ToDecimal(price.Text.ToString());
            //int p2 = Convert.ToInt32(cantidad.Text.ToString());

            //decimal p3;

            //p3 = p1 * p2;
            //cantidadtxt.Text = "Cantidad a ordenar:" + p2;
            //Total.Text = "Su Total es de:" + p3;

        }


        public async void BtnOrdenar_Clicked(object sender, EventArgs e)
        {
            var newreservacion = new detallereservacion
            {
                idreservacion = Constantes.idreservacion,
                idproducto = Convert.ToInt32(idd.Text),
                cantidad = Convert.ToInt32(cantidad.Text)
            };
           

            //reservacion newreserva = new reservacion
            //{
            //    id = Constantes.idreservacion,
            //    idcliente = Constantes.idusuario,
            //    total = Convert.ToInt32(Total.Text),
            //    detallereservacions = newreservacion
            //}; 


            var json = JsonConvert.SerializeObject(newreservacion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PostAsync("http://paraisoreal19.somee.com/api/detallereservacions/Postdetallereservacion", content);

            var instanceprocesos = new procesos.operaciones(Constantes.idusuario, Constantes.idreservacion);

            if (result.StatusCode == HttpStatusCode.Created)
            {
                await App.Current.MainPage.DisplayAlert("Genial!", " Tu registro se ha realizado con exito", "Ok");
                await App.Current.MainPage.Navigation.PushAsync(new VerOrden());


            }



        }

        
    }

     
    }

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

        }

        public async void BtnOrdenar_Clicked(object sender, EventArgs e)
        {
            var newreservacion = new detallereservacion
            {
                idreservacion = Constantes.idreservacion,
                idproducto = Convert.ToInt32(idd.Text),
                cantidad = Convert.ToInt32(cantidad.Text)
            };
           
            
            var json = JsonConvert.SerializeObject(newreservacion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PostAsync("http://paraisoreal19.somee.com/api/detallereservacions/Postdetallereservacion", content);

            var instanceprocesos = new procesos.operaciones(Constantes.idusuario, Constantes.idreservacion);

            if (result.StatusCode == HttpStatusCode.Created)
            {
                await App.Current.MainPage.DisplayAlert("Genial!", " Tu registro se ha realizado con exito", "Ok");
               // await App.Current.MainPage.Navigation.PushAsync(new VerOrden());

            }

        }

        public async void BtnverOrden_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new VerOrden());

        }
    }

     
    }
